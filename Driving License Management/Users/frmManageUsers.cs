using Driving_License_Management.Users;
using DVDLBusinessLayar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Management
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }



        DataTable GetAllUsers = User.GetAllUsers();

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            GetAllUsers = User.GetAllUsers();
            dgvUsers.DataSource = GetAllUsers;

            cbFilterBy.SelectedIndex = 0;
           

            int RowCount = dgvUsers.Rows.Count;
            lblRecords.Text = RowCount.ToString();

            if (RowCount > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 100;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 100;

                dgvUsers.Columns[2].HeaderText = "Full Name";
                dgvUsers.Columns[2].Width = 300;


                dgvUsers.Columns[3].HeaderText = "User Name";
                dgvUsers.Columns[3].Width = 150;

                dgvUsers.Columns.Remove("IsActive");

                DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
                column.Name = "IsActive";
                column.HeaderText = "Is Active";
                column.Width = 100;

                dgvUsers.Columns.Add(column);
                column.DataPropertyName = "IsActive";
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilterBy.Text == "Is Active")
            {
                txtFilter.Visible=false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
               
            }
            else
            {
                txtFilter.Visible = (cbFilterBy.Text != "None");
                cbIsActive.Visible = false;

                txtFilter.Text="";
                txtFilter.Focus();
            }
        }

        private void Filter()
        {
            string Filter = "";
            switch (cbFilterBy.SelectedIndex)
            {
                case 1:
                    Filter = "UserID";
                    break;

                case 2:
                    Filter = "PersonID";
                    break;

                case 3:
                    Filter = "FullName";
                    break;

                case 4:
                    Filter = "UserName";
                    break;

                case 5:
                    Filter = "IsActive";
                    break;

            }

            if ((txtFilter.Text.Trim() == "" || cbFilterBy.Text == "None"))
            {
                GetAllUsers.DefaultView.RowFilter = "";
                lblRecords.Text = dgvUsers.Rows.Count.ToString();
                return;
            }

           

            if (Filter != "FullName" && Filter != "UserName")
            {
               
                GetAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", Filter, txtFilter.Text.Trim());
            }
            else
            {
                GetAllUsers.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", Filter, txtFilter.Text.Trim());
            }

                lblRecords.Text = dgvUsers.Rows.Count.ToString();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {

            Filter();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumn = "IsActive";
            string FilterValue = "";

            switch (cbIsActive.Text)
            {
                case "All":
                    break;
                case "Yas":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }

            if (cbIsActive.Text == "All")
            {
                GetAllUsers.DefaultView.RowFilter = "";
            }
            else
                GetAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
         
                
                    
                
            lblRecords.Text = dgvUsers.Rows.Count.ToString();
        }
      

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmEditUser editUser = new frmEditUser();
            editUser.ShowDialog();
            frmManageUsers_Load(null, null);
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 2)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }


        private void smiEditUser_Click(object sender, EventArgs e)
        {
            frmEditUser editUser = new frmEditUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            editUser.ShowDialog();
            frmManageUsers_Load(null, null);
        }

        private void smiShowDetails_Click(object sender, EventArgs e)
        {
            frmShowUserDetails userDetails = new frmShowUserDetails((int)dgvUsers.CurrentRow.Cells[0].Value);
            userDetails.ShowDialog();
            frmManageUsers_Load(null, null);
        }

        private void smiDeleteUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (User.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmManageUsers_Load(null, null);
                }
                else
                    MessageBox.Show("User is not delted due to data connected to it.", "Faild",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void smiAddNewUser_Click(object sender, EventArgs e)
        {
            frmEditUser editUser = new frmEditUser();
            editUser.ShowDialog();
            frmManageUsers_Load(null, null);
        }

        private void smiChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword =new frmChangePassword((int)dgvUsers.CurrentRow.Cells[0].Value);
            changePassword.ShowDialog();
        }
    }
}
