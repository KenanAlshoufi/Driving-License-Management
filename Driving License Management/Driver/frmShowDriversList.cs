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
    public partial class frmShowDriversList : Form
    {
        public frmShowDriversList()
        {
            InitializeComponent();
        }

        DataTable GetAllDrivers;

        private void frmShowDriversList_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;

            GetAllDrivers = Drivers.GetAllDrivers();
            dgvDrivers.DataSource = GetAllDrivers;


            int RowCount = dgvDrivers.Rows.Count;
            lblRecords.Text = RowCount.ToString();

            if (RowCount > 0)
            {
                dgvDrivers.Columns[0].HeaderText = "Driver ID";
                dgvDrivers.Columns[0].Width = 80;

                dgvDrivers.Columns[1].HeaderText = "Person ID";
                dgvDrivers.Columns[1].Width = 80;

                dgvDrivers.Columns[2].HeaderText = "National No";
                dgvDrivers.Columns[2].Width = 100;


                dgvDrivers.Columns[3].HeaderText = "Full Name";
                dgvDrivers.Columns[3].Width = 250;

                dgvDrivers.Columns[4].HeaderText = "Date";
                dgvDrivers.Columns[4].Width = 150;

                dgvDrivers.Columns[5].HeaderText = "Active License";
                dgvDrivers.Columns[5].Width = 100;

            }
        }

        private void Filter()
        {
            string Filter = "";
            switch (cbFilterBy.SelectedIndex)
            {
                case 1:
                    Filter = "DriverID";
                    break;

                case 2:
                    Filter = "PersonID";
                    break;

                case 3:
                    Filter = "NationalNo";
                    break;

                case 4:
                    Filter = "FullName";
                    break;

             
            }

            if ((txtFilter.Text.Trim() == "" || cbFilterBy.Text == "None"))
            {
                GetAllDrivers.DefaultView.RowFilter = "";
                lblRecords.Text = dgvDrivers.Rows.Count.ToString();
                return;
            }



            if (Filter != "FullName" && Filter != "NationalNo")
            {

                GetAllDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}", Filter, txtFilter.Text.Trim());
            }
            else
            {
                GetAllDrivers.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", Filter, txtFilter.Text.Trim());
            }

            lblRecords.Text = GetAllDrivers.Rows.Count.ToString();
        }


        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 2)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonDetails personDetails = new frmShowPersonDetails((int)dgvDrivers.CurrentRow.Cells[1].Value);
            personDetails.ShowDialog();


        }

        private void showPerosnLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonLicenseHistory personLicenseHistory = new frmShowPersonLicenseHistory((int)dgvDrivers.CurrentRow.Cells[1].Value);
            personLicenseHistory.ShowDialog();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = (cbFilterBy.Text != "None");


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
}
