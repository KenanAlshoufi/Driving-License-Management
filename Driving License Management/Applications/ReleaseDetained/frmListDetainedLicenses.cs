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
using System.Xml.Linq;

namespace Driving_License_Management
{
    public partial class frmListDetainedLicenses : Form
    {
        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        DataTable GetAllDetainLicenses;
        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;

            GetAllDetainLicenses = clsDetain.GetAllDetain();
            dgvDetainedLicenses.DataSource = GetAllDetainLicenses;


            int RowCount = dgvDetainedLicenses.Rows.Count;
            lblRecords.Text = RowCount.ToString();

            if (RowCount > 0)
            {
                dgvDetainedLicenses.Columns[0].HeaderText = "Detain ID";
                dgvDetainedLicenses.Columns[0].Width = 80;

                dgvDetainedLicenses.Columns[1].HeaderText = "License ID";
                dgvDetainedLicenses.Columns[1].Width = 80;

                dgvDetainedLicenses.Columns[2].HeaderText = "Detain Date";
                dgvDetainedLicenses.Columns[2].Width = 150;

                dgvDetainedLicenses.Columns[3].HeaderText = "Is Releaseed";
                dgvDetainedLicenses.Columns[3].Width = 80;


                dgvDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[4].Width = 100;


                dgvDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns[5].Width = 150;

                dgvDetainedLicenses.Columns[6].HeaderText = "National No";
                dgvDetainedLicenses.Columns[6].Width = 150;

                dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[7].Width = 200;


                dgvDetainedLicenses.Columns[8].HeaderText = "R App ID";
                dgvDetainedLicenses.Columns[8].Width = 100;


            }
        }

        private void Filter()
        {

            string Filter = "";
            switch (cbFilterBy.SelectedIndex)
            {
                case 1:
                    Filter = "DetainID";
                    break;

                case 3:
                    Filter = "NationalNo";
                    break;

                case 4:
                    Filter = "FullName";
                    break;
                case 5:
                    Filter = "ReleaseApplicationID";
                    break;

            }

            if ((txtFilter.Text.Trim() == "" || cbFilterBy.Text == "None"))
            {
                GetAllDetainLicenses.DefaultView.RowFilter = "";
                lblRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
                return;
            }



            if (Filter != "FullName" && Filter != "NationalNo")
            {

                GetAllDetainLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", Filter, txtFilter.Text.Trim());
            }
            else
            {
                GetAllDetainLicenses.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", Filter, txtFilter.Text.Trim());
            }

            lblRecords.Text = GetAllDetainLicenses.Rows.Count.ToString();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void cbIsRelease_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsReleased";
            string FilterValue = cbIsRelease.Text;

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
                GetAllDetainLicenses.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                GetAllDetainLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecords.Text = GetAllDetainLicenses.Rows.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Release")
            {
                txtFilter.Visible = false;
                cbIsRelease.Visible = true;
                cbIsRelease.Focus();
                cbIsRelease.SelectedIndex = 0;

            }
            else
            {
                txtFilter.Visible = (cbFilterBy.Text != "None");
                cbIsRelease.Visible = false;

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

        private void showPersonDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowPersonDetails personDetails=new frmShowPersonDetails((string)dgvDetainedLicenses.CurrentRow.Cells[6].Value);
            personDetails.ShowDialog();

        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriverLicenseInfo drivingLicenseInfo = new frmDriverLicenseInfo((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            drivingLicenseInfo.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            People people = People.FindByNationalNo((string)dgvDetainedLicenses.CurrentRow.Cells[6].Value);
            if (people == null)
            {
                return;
            }

            frmShowPersonLicenseHistory personLicenseHistory =new frmShowPersonLicenseHistory(people.PersonID);
            personLicenseHistory.ShowDialog();
        }

        private void relaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmReleaseDetainedLicense releaseDetainedLicense = new frmReleaseDetainedLicense((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            releaseDetainedLicense.ShowDialog();
            frmListDetainedLicenses_Load(null, null);
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
              relaseDetainedLicenseToolStripMenuItem.Enabled = !(bool)dgvDetainedLicenses.CurrentRow.Cells[3].Value;
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1 )
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense detainLicense = new frmDetainLicense();
            detainLicense.ShowDialog();
            frmListDetainedLicenses_Load(null, null);
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense releaseDetainedLicense = new frmReleaseDetainedLicense();
            releaseDetainedLicense.ShowDialog();
            frmListDetainedLicenses_Load(null, null);
        }
    }
}
