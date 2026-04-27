using DVDLBusinessLayar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Management
{
    public partial class ctrlPersonLicenseHistory : UserControl
    {
        private int _DriverID;
        private Drivers _Driver;
        private DataTable _dtDriverLocalLicensesHistory;
        private DataTable _dtDriverInternationalLicensesHistory;

        public ctrlPersonLicenseHistory()
        {
            InitializeComponent();
        }

    
        private void _LoadLocalLicenseInfo()
        {

            _dtDriverLocalLicensesHistory = Drivers.GetAllLocalDrivingLicenseByDriverID(_DriverID);


            dgvLocalLicense.DataSource = _dtDriverLocalLicensesHistory;
            lblRecords.Text = _dtDriverLocalLicensesHistory.Rows.Count.ToString();

            if (dgvLocalLicense.Rows.Count > 0)
            {
                dgvLocalLicense.Columns[0].HeaderText = "Lic.ID";
                dgvLocalLicense.Columns[0].Width = 110;

                dgvLocalLicense.Columns[1].HeaderText = "App.ID";
                dgvLocalLicense.Columns[1].Width = 110;

                dgvLocalLicense.Columns[2].HeaderText = "Class Name";
                dgvLocalLicense.Columns[2].Width = 270;
                
                dgvLocalLicense.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicense.Columns[3].Width = 170;
                
                dgvLocalLicense.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicense.Columns[4].Width = 170;
                
                dgvLocalLicense.Columns[5].HeaderText = "Is Active";
                dgvLocalLicense.Columns[5].Width = 110;

            }
        }

        private void _LoadInternationalLicenseInfo()
        {

            _dtDriverInternationalLicensesHistory = InternaionalLicense.GetDriverInternationalLicenses(_DriverID);


            dgvInternationalHistory.DataSource = _dtDriverInternationalLicensesHistory;
            lblRecords.Text = _dtDriverInternationalLicensesHistory.Rows.Count.ToString();

            if (_dtDriverInternationalLicensesHistory.Rows.Count > 0)
            {
                dgvInternationalHistory.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalHistory.Columns[0].Width = 160;

                dgvInternationalHistory.Columns[1].HeaderText = "Application ID";
                dgvInternationalHistory.Columns[1].Width = 130;

                dgvInternationalHistory.Columns[2].HeaderText = "L.License ID";
                dgvInternationalHistory.Columns[2].Width = 130;

                dgvInternationalHistory.Columns[3].HeaderText = "Issue Date";
                dgvInternationalHistory.Columns[3].Width = 180;

                dgvInternationalHistory.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalHistory.Columns[4].Width = 180;

                dgvInternationalHistory.Columns[5].HeaderText = "Is Active";
                dgvInternationalHistory.Columns[5].Width = 120;

            }
        }

        public void LoadInfo(int DriverID)
        {
            _DriverID = DriverID;
            _Driver = Drivers.FindDriverByID(_DriverID);

            if (_Driver == null)
            {
                MessageBox.Show("There is no driver with Id = " + DriverID, "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return;
            }

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();

        }

        public void LoadInfoByPersonID(int PersonID)
        {

            _Driver = Drivers.FindDriverByPersonID(PersonID);

            if (_Driver == null)
            {
                MessageBox.Show("There is no Driver Linked with Perosn with Id = " + PersonID, "Error", MessageBoxButtons.OK
                   , MessageBoxIcon.Error);
                return;
            }
            _DriverID = _Driver.DriverID;

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();
        }

        public void Clear()
        {
            _dtDriverLocalLicensesHistory.Clear();
            _dtDriverInternationalLicensesHistory.Clear();

        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvLocalLicense.CurrentRow.Cells[0].Value;
            frmDriverLicenseInfo frm = new frmDriverLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)dgvInternationalHistory.CurrentRow.Cells[0].Value;
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(InternationalLicenseID);
            frm.ShowDialog();
        }
    }
}
