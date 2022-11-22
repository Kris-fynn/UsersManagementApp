using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersManagementApp.General;

namespace UsersManagementApp.Forms
{
    public partial class RolesForm : TemplateForm
    {
        public bool IsFormValid { get; private set; }

        public RolesForm()
        {
            InitializeComponent();
        }
         
        //Properties to Handle updates Process
        public int RoleId { get; set; }
        public bool IsUpdate { get; set; }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                if(this.IsUpdate)
                {
                    // Do update Operation
                    using (SqlConnection con = new SqlConnection(AppConnection.GetConnectionString()))
                    {
                        using (SqlCommand cmd = new SqlConnection("usp_Roles_UpdateRoleByRoleId", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@RoleId", TitleTextBox.Text.Trim())
                            cmd.Parameters.AddWithValue("@RoleTitle", TitleTextBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@Description", DescriptionTextBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@CreatedBy", "Admin");

                            if (con.State != ConnectionState.Open)
                            {
                                con.Open();
                            }

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Role is successfully updated in the database.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ResetFormControl();
                        }
                    }

                }
                else
                {
                    //Do Insert Operation
                    using (SqlConnection con = new SqlConnection(AppConnection.GetConnectionString()))
                    {
                        using (SqlCommand cmd = new SqlConnection("usp_Roles_InsertNewRole", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@RoleTitle", TitleTextBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@Description", DescriptionTextBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@CreatedBy", "Admin");

                            if (con.State != ConnectionState.Open)
                            {
                                con.Open();
                            }

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Role is successfully saved in the database.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ResetFormControl();
                        }
                    }
                }
            }
        }
        private void ResetFormControl()
        {
            TitleTextBox.Clear();
            DescriptionTextBox.Clear();
            
            TitleTextBox.Focus();

            //
             if(this.IsUpdate)
             {
                this.RoleId = 0;
                this.IsUpdate = false;
                SaveButton.Text = "Save Information";
                DeleteButton.Enabled = false;



             } 
        private bool IsFormValid
        {
            if(TitleTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Roles Title is Required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TitleTextBox.Focus();
                return false;
            }
            if (TitleTextBox.Text.Length >= 50)
            {
                MessageBox.Show("Roles Title should be Less than or equals to 50 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TitleTextBox.Focus();
                return false;
            }
            return true;
        }
        
        private void RolesForm_Load(object sender, EventArgs e)
        {
             if (this.IsUpdate == true)// or Use simple if(this.IsUpdate) function 
             {
                   using (SqlConnection con = new SqlConnection(AppConnection.GetConnectionString())
                   {
                       using (SqlConnection cmd = new SqlConnection("usp_Roles_ReloadDataForUpdate", con))
                       {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@RolesId", RoleId);

                            if(con.State != ConnectionState.Open)
                               con.Open();

                            DataTable dtRole = new DataTable();

                            SqlDataReader sdr = cmd.ExecuteReader();

                            dtRole.Load(sdr); 
                
                            DataRow row = dtRole.Rows[0];
                          
                            TitleTextBox.Text = row["Title"].ToString();

                            DescriptionText = row["Description"].ToString();

                           // Change Controls
                           SaveButton.Text = "Update Role Information";
                           DeleteButton.Enabled = true;


                       }
                   }
                   // MessageBox.Show("Form is loaded for updade process");

             }
             // else 
             //{ 
             //    MessageBox.Show("Form is loaded for insert process")
             //}

        private void DeleteButton_Click(object sender, EventArgs e)
        {
              if (this.IsUpdate)
              {
                    DialogResult result = MessageBox.Show("Are sure you want to delete this Role?", "Comformation", MessageBoxButtons.YesNo, MessageBoxButtonIcon.Question);   
                    
                    if (result == DialogResult.Yes) 
                    {
                         //Delete record from Database
                         using (SqlConnection con = new SqlConnection(AppConnection.GetConnectionString()))
                         {
                                using (SqlCommand cmd = new SqlCommand("usp_Roles_DeleteById", con))
                                {
                                     cmd.CommandType = CommandType.StoredProcedure;

                                     cmd.Parameters.AddWithValue("@RoleId", this.RoleId);

                                     if (con.State != ConnectionState.Open)
                                     con.Open();

                                     cmd.ExecuteNonQuery();

                                     MessageBox.Show("Role is successfully deleted from the system.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                     ResetFormControl();
                                }
                         }

                    }


              }
        }
        }
}
