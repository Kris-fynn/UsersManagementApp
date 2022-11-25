using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersManagementApp.General;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UsersManagementApp.Forms
{
    public partial class UserForm : TemplateForm
    {
        public UserForm()
        {
            InitializeComponent();
        }

        //Properties to handle updatesvand delete operations
        public string Username { get; set; }
        public bool IsUpdate { get; set; }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            LoadDataIntoRolesComboBox();

            // For Update Process
            if (this.IsUpdate == true)// or Use simple if(this.IsUpdate) function 
            {
                using (SqlConnection con = new SqlConnection(AppConnection.GetConnectionString())
                {
                       using (SqlConnection cmd = new SqlConnection("usp_Users_ReloadDataForUpdate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserName", this.Username);

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    DataTable dtUser = new DataTable();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    dtUser.Load(sdr);

                    DataRow row = dtUser.Rows[0];

                    Username.TextBox.Text = row["UserName"];
                    RolesComboBox.SelectedValue = row["RoleId"];
                    IsActiveCheckBox.Checked = Convert.ToBoolean(row["IsActive"]);
                    Description.TextBox.Text = row["Description"].ToString();

                    // Change Controls
                    SaveButton.Text = "Update User Information";
                    DeleteButton.Enabled = true;


                       }
            }
            }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            If(IsFormValid())
            {
                if(this.IsUpdate =+ true)
                {
                    //Do update Process
                    using (SqlConnection con = new SqlConnection(AppConnection.GetConnectionString()))
                    {
                        using (SqlCommand cmd = new SqlConnection("", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@UserName", UserNameTextBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@Password", SecureData.EncryptData(PasswordTextBox.Text.Trim()));
                            cmd.Parameters.AddWithValue("@RoleId", RolesComboBox.SelectedValue);
                            cmd.Parameters.AddWithValue("@IsActive", IsActiveCheckBox.Checked);
                            cmd.Parameters.AddWithValue("@Description", DescriptionTextBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@CreatedBy", "Admin");


                            if (con.State != ConnectionState.Open)
                            {
                                con.Open();
                            }

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("User is successfully saved in the database.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ResetFormControl();
                        }
                    }
                }
                else
                {
                    //Do Insert Operation
                    using (SqlConnection con = new SqlConnection(AppConnection.GetConnectionString()))
                    {
                        using (SqlCommand cmd = new SqlConnection("usp_Users_InsertNewUser", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@UserName", UserNameTextBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@Password", SecureData.EncryptData(PasswordTextBox.Text.Trim()));
                            cmd.Parameters.AddWithValue("@RoleId", RolesComboBox.SelectedValue);
                            cmd.Parameters.AddWithValue("@IsActive", IsActiveCheckBox.Checked);
                            cmd.Parameters.AddWithValue("@Description", DescriptionTextBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@CreatedBy", "Admin");


                            if (con.State != ConnectionState.Open)
                            {
                                con.Open();
                            }

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("User is successfully saved in the database.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ResetFormControl();
                        }
                    }

                }

            }
        }
        // MessageBox.Show("Form is loaded for updade process");

    }
    }

        private void LoadDataIntoRolesComboBox()
        {
            using (SqlConnection con = new SqlConnection(AppConnection.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_Roles_LoadDataIntoComboBox", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    if (con.State!=ConnectionState.Open)
                        con.Open();

                    DataTable dtRoles = new DataTable();

                    SqlDataReader sqlDataReader sdr = cmd.ExecuteReader();

                    dtRoles.Load(sdr);

                    RolesComboBox.DataSource = dtRoles;
                    RolesComboBox.DisplayMember= "RoleTitle";
                    RolesComboBox.ValueMember = "RoleId";
                }
            }
        }

        private void saveInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                //Do Insert Operation
                using (SqlConnection con = new SqlConnection(AppConnection.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlConnection("usp_U", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserName", UserNameTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", SecureData.EncryptData(PasswordTextBox.Text.Trim())); 
                        cmd.Parameters.AddWithValue("@RoleId", RolesComboBox.SelectedValue);
                        cmd.Parameters.AddWithValue("@IsActive", IsActiveCheckBox.Checked);
                        cmd.Parameters.AddWithValue("@Description", DescriptionTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@CreatedBy", "Admin");


                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("User is successfully saved in the database.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ResetFormControl();
                    }
                }
            }

        }

        private void ResetFormControl()
        {
            UserNameTextBox.Clear();    
            PasswordTextBox.Clear();
            RolesComboBox.SelectedIndex= 0;
            IsActiveCheckedBox.Checked = true;
            DescriptionTextBoxClear();

            UserNameTextBox.Focus();
        }

        private bool IsFormValid()
        {
            if (UserNameTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("User Name is Required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserNameTextBox.Focus();
                return false;
            }
            if (UserNameTextBox.Text.Length >= 50)
            {
                MessageBox.Show("User Name length should be Less than or equals to 50 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserNameTextBox.Focus();
                return false;
            }

            if (PasswordText.Trim() == string.Empty)
            {
                MessageBox.Show("Password is Required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordTextBox.Focus();
                return false;
            }
            if (PasswordTextBox.Text.Length >= 50)
            {
                MessageBox.Show("Password lenght should be Less than or equals to 50 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordTextBox.Focus();
                return false;
            }

             if(RolesComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select user role from drop down manu.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PRolesComboBox.Focus();
                return false;
            }
            return true;
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //   Messege.Show(SecureData.EncryptData(SimpleStringTextBox.Text));
        //  }
    }
}
