using DVDLBusinessLayar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Management
{
    public partial class frmManageInternationalLicenseApplication : Form
    {
        public frmManageInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        DataTable GetAllInternationalLicenses;

        private void Filter()
        {
            
            string Filter = "";
            switch (cbFilterBy.SelectedIndex)
            {
                case 1:
                    Filter = "InternationalLicenseID";
                    break;

                case 2:
                    Filter = "ApplicationID";
                    break;

                case 3:
                    Filter = "DriverID";
                    break; 
                case 4:
                    Filter = "IssuedUsingLocalLicenseID";
                    break;

            }

            if ((txtFilter.Text.Trim() == "" || cbFilterBy.Text == "None"))
            {
                GetAllInternationalLicenses.DefaultView.RowFilter = "";
                lblRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();
                return;
            }

           GetAllInternationalLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", Filter, txtFilter.Text.Trim());
          

            lblRecords.Text = GetAllInternationalLicenses.Rows.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Active")
            {
                txtFilter.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;

            }
            else
            {
                txtFilter.Visible = (cbFilterBy.Text != "None");
                cbIsActive.Visible = false;

                if (cbFilterBy.Text == "None")
                {
                    txtFilter.Enabled = false;
                }
                else
                    txtFilter.Enabled = true;

                txtFilter.Text = "";
                txtFilter.Focus();
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                GetAllInternationalLicenses.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                GetAllInternationalLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecords.Text = GetAllInternationalLicenses.Rows.Count.ToString();
        }

     
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void frmManageInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;

            GetAllInternationalLicenses = InternaionalLicense.GetAllInternationalLicenses();
            dgvInternationalLicenses.DataSource = GetAllInternationalLicenses;


            int RowCount = dgvInternationalLicenses.Rows.Count;
            lblRecords.Text = RowCount.ToString();

            if (RowCount > 0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "Int License ID";
                dgvInternationalLicenses.Columns[0].Width = 150;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 80;

                dgvInternationalLicenses.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenses.Columns[2].Width = 150;

               
                dgvInternationalLicenses.Columns[3].HeaderText = "L License ID";
                dgvInternationalLicenses.Columns[3].Width = 100;


                dgvInternationalLicenses.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[4].Width = 150;

                dgvInternationalLicenses.Columns[5].HeaderText = "Expraion Date";
                dgvInternationalLicenses.Columns[5].Width = 150;

                dgvInternationalLicenses.Columns[6].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[6].Width = 150;
            }
        }

        private void showPersonDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Drivers drivers = Drivers.FindDriverByID((int)dgvInternationalLicenses.CurrentRow.Cells[2].Value);

            if (drivers == null)
            {
                return;
            }

            frmShowPersonDetails personDetails = new frmShowPersonDetails(drivers.PersonID);
            personDetails.ShowDialog();
            frmManageInternationalLicenseApplication_Load(null, null);
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseInfo drivingLicenseInfo = new frmInternationalLicenseInfo((int)dgvInternationalLicenses.CurrentRow.Cells[0].Value);
            drivingLicenseInfo.ShowDialog();


        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Drivers drivers = Drivers.FindDriverByID((int)dgvInternationalLicenses.CurrentRow.Cells[2].Value);

            if (drivers == null)
            {
                return;
            }

            frmShowPersonLicenseHistory personLicenseHistory = new frmShowPersonLicenseHistory(drivers.PersonID);
            personLicenseHistory.ShowDialog();
        }

        private void btnAddILicenseApplication_Click(object sender, EventArgs e)
        {
            frmIssueInternationalLicenseApplication frm =new frmIssueInternationalLicenseApplication();
            frm.ShowDialog();

            frmManageInternationalLicenseApplication_Load(null, null);

        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
          
        }
    }
}
