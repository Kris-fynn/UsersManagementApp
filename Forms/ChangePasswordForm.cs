using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsersManagementApp.Forms
{
    public partial class ChangePasswordForm : TemplateForm
    {
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


            }
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
