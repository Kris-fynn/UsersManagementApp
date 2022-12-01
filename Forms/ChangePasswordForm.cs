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
    public partial class ChangePasswordForm : TemplateForm
    {
        public object MessageBoxButton { get; private set; }

        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            if(IsFormValid()) 
            {
                //Verify Existing Password
                if (IsPasswordVarified())
                {
                    // Go and Update Password

                    using (SqlConnection con = new SqlConnection(AppConnection.GetConnectionString()))
                    {
                        using (SqlCommand cmd = new SqlConnection("usp_Users_ChangePassword", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@UserName", LoggedInUser.UserName);
                            cmd.Parameters.AddWithValue("@NewPassword", SecureData.EncryptData(NewPasswordTextBox.Text.Trim()));
                            cmd.Parameters.AddWithValue("@CreatedBy", LoggedInUser.UserName);


                            if (con.State != ConnectionState.Open)
                            {
                                con.Open();
                            }

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Password is successfully Changed.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ResetFormControl();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Your old password is not correct, please enter correct password", "Failed", MessageBoxButton.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void ResetFormControl()
        {
            NewPasswordTextBox.Clear();
            OldPasswordTextBox.Clear();
            ConfirmPasswordTextBox.Clear();

            OldPasswordTextBox.Focus();

        }

        private bool IsPasswordVarified()
        {    
            bool IsCorrect = false;
            using (SqlConnection con = new SqlConnection(AppConnection.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_Users_VerifyPassword", con)
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName", LoggedInUser.UserName);
                    cmd.Parameters.AddWithValue("@Password", SecureData.EncryptData(OldPasswordTextBox.Text.Trim());
                

                if (con.State!=ConnectionState.Open)

                    con.Open();

                SqlDataReader sdr = cmd.ExecuteReader();


                if (sdr.HasRows)
                {
                    IsCorrect = true;
                }
            }
        }
        return IsCorrect;
    }

        private bool IsFormValid()
        {
            if(OldPasswordTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Old Password is Required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OldPasswordTextBox.Focus();
                return false;
            }

            if (NewPasswordTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("New Password is Required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NewPasswordTextBox.Focus();
                return false;
            }

            if (ConfirmPasswordTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Confirm Password is Required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConfirmPasswordTextBox.Focus();
                return false;
            }

            if (NewPasswordTextBox.Text.Trim() != ConfirmPasswordTextBox.Text.Trim())
            {
                MessageBox.Show("New and Confirm Password is not Matched", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NewPasswordTextBox.Focus();
                return false;
            }

            return true;
        }
    }
}
