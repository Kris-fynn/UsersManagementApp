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

namespace UsersManagementApp.Forms
{
    public partial class ViewUsersForm : TemplateForm
    {
        public ViewUsersForm()
        {
            InitializeComponent();
            LoadDataIntoDataGridView();

        }

        private void LoadDataIntoDataGridView()
        {
            using (SqlConnection con = new SqlConnection(AppConnection.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_Users_LoadDataIntoDataGridView", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    if (con.State!=ConnectionState.Open)

                        con.Open();

                    DataTable dtRoles = new DataTable();

                    SqlDataReader sqlDataReader sdr = cmd.ExecuteReader();

                    dtRoles.Load(sdr);

                    UsersDataGridView.DataSource = dtRoles;
                    //RolesDataGridView.Columns[].Visible=false;

                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm usersForm= new UsersForm();
            usersForm.ShowDialog();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (SearchTextBox.Text != string.Empty)
            {
                using (SqlConnection con = new SqlConnection(AppConnection.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_Users_SearchByUserNameorRole", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //Passing Parameter
                        SqlParameter sqlParameter = cmd.Parameters.AddWithValue("@Filer", SearchTextBox.Text.Trim());

                        if (con.State !=ConnectionState.Open) ;
                        con.Open();

                        DataTable dtRole = new DataTable();

                        SqlDataReader sdr = cmd.ExecuteReader();

                        if (sdr.HasRows)
                        {
                            dtRole.Load(sdr);

                            UsersDataGridView.DataSource = dtRole;
                        }
                        else
                        {
                            MassegeBox.Show("No Matching USer is Fund.", "No Record", MessageBoxButtons.OK, MessegeBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void refreshRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void UsersDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(UsersDataGridView.Rows.Count > 0)
            {
                string userName = UsersDataGridView.SelectedRows[0].Cells[0].Value.ToString();
                //MessageBox.Show(userName);
                UsersForm usersForm = new UsersForm();
                usersForm.Username= userName; 
                usersForm.IsUpdate= true;   
                usersForm.ShowDialog();
                LoadDataIntoDataGridView();
                

            }
        }
    }
}
