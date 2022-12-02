using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersManagementApp.General;

namespace UsersManagementApp.Forms
{
    public partial class DashboardForm : TemplateForm
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void exitApplictionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chengePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm cpf = new ChangePasswordForm();
            cpf.ShowDialog();
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            userForm.ShowDialog();
        }

        private void viewUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewUsersForm vuf = new ViewUsersForm();
            vuf.ShowDialog();
        }

        private void newRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RolesForm rf = new RolesForm();
            rf.ShowDialog();
        }

        private void viewRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewRolesForm vrf = new ViewRolesForm();
            vrf.ShowDialog();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            AdminLabel.Text = LoggedInUser.UserName;
            //RoleLabel.Text = LoggedInUser.RoleId.ToString();

            SetupUserAccess();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if(LoggedInUser.RoleId == 1)
            {
                //Display Form and Do what you want
            }
            else
            {
                MessageBox.Show("You are not allowed to perform this operation.", "Access Denied", MessageBoxIcon.Information);
            }
          
        }

        private void SetupUserAccess()
        {
            switch(LoggedInUserUser.RoleId)
            {
                case 1:
                    RoleLabel.Text = "Full Rights";
                    AdminMenu.Visible  = true;

                    break;
                case 2:
                    RoleLabel.Text = "Normal Rights";
                    break;
                case 3:
                    RoleLabel.Text = "Limited Rights";
                    break;
            } 

        }

        private void RoleLabel_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
