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
    public partial class ViewRolesForm : TemplateForm
    {
        private object RolesDataGridView;

        public IDataReader sdr { get; private set; }
        public object SearchTextBox { get; private set; }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        public ViewRolesForm()
        {
            InitializeComponent();
            LoadDataIntoDataGridView();

        }
        private void LoadDataIntoDataGridView()
        {
            using (SqlConnection con = new SqlConnection(AppConnection.GetConnectionString()))
            {
                using(SqlCommand cmd = new SqlCommand("usp_Roles_LoadDataIntoGridView", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    if(con.State!=ConnectionState.Open)
                    
                        con.Open();

                    DataTable dtRoles = new DataTable();

                    SqlDataReader sqlDataReader sdr = cmd.ExecuteReader();

                    dtRoles.Load(sdr);

                    RolesDataGridView.DataSource = dtRoles;
                    //RolesDataGridView.Columns[].Visible=false;

                }
            }
        }

       

        private void SearchTextBox.Text_Click(object sender, EventArgs e)
        {
            if(SearchText.Text != string.Empty)
            {
               using (SqlConnection con = new SqlConnection(AppConnection.GetConnectionString())) 
                {
                    using(SqlCommand cmd = new SqlCommand("usp_Roles_SearchByTitle", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //Passing Parameter
                        SqlParameter sqlParameter = cmd.Parameters.AddWithValue("@RoleTitle", SearchTextBox.Text.Trim());

                        if (con.State !=ConnectionState.Open);
                            con.Open();

                        DataTable dtRole = new DataTable();

                        SqlDataReader sdr = cmd.ExecuteReader();

                        if (sdr.HasRows)
                        {
                            dtRole.Load(sdr);

                            RolesDataGridView.DataSource = dtRole;
                        }
                        else
                        {
                            MassegeBox.Show("No Matching Role is Fund.", "No Record", MessageBoxButtons.OK, MessegeBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void refreshRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
            SearchTextBox.Clear();
            SearchTextBox.Focus();
        }

        private void newRoleToolStriMenuStrip_Click(object sender, EventArgs e)
        {
            RolesForm rf = new RolesForm();   
            rf.ShowDialog();
            LoadDataIntoDataGridView();
        }

        private void RolesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(RolesDataGridView.Rows.Count > 0)
            {
                int roleId = Convert.ToInt32(RolesDataGridView.SelectedRows[0].Cells[0].Value);
                //MessageBox.Show(roleId.ToString());

                RolesForm rolesForm = new RolesForm();
                rolesForm.RoleId = roleId;
                rolesForm.IsUpdate = true;
                rolesForm.ShowDialog();

                LoadDataIntoDataGridView();

            }
        }
    }
}
