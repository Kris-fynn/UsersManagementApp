using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersManagementApp.General;

namespace UsersManagementApp.Forms
{
    public partial class Login : TemplateForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
          Application.Exit();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if(IsFormValid())
            {
                using (SqlConnection con = new SqlConnection(AppConnection.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_Users_VerifyLoginDetails", con)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserName", UserNameTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", SecureData.EncryptData(PasswordTextBox.Text.Trim()));

                    if (con.State!=ConnectionState.Open)

                            con.Open();

                        DataTable dtRoles = new DataTable();

                        SqlDataReader  sdr = cmd.ExecuteReader();

                        
                        if(sdr.HasRows) 
                        {
                            dtRoles.Load(sdr);
                            MessageBox.Show("Login Successfully")
                        }
                        else
                        {
                            MessageBox.Show("User Name or Password is incorrect", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }

            private bool IsFormValid()
            {
                if (UserNameTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("User Name is Required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UserNameTextBox.Focus();
                    return false;
                }

                if (PasswordTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Password is Required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PasswordTextBox.Focus();
                    return false;
                }

                return true;
            }
        }
    }
}
