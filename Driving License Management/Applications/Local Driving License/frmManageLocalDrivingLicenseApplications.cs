using DVDLBusinessLayar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVDLBusinessLayar.Applications;
using static DVDLBusinessLayar.TestTypes;

namespace Driving_License_Management
{
    public partial class frmManageLocalDrivingLicenseApplications : Form
    {
        public frmManageLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        DataTable DrivingLicenseLocal;
        private void frmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            DrivingLicenseLocal = LocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications();
            dgvDrivingLicenseLocal.DataSource = DrivingLicenseLocal;

            cbFilterBy.SelectedIndex = 0;


            int RowCount = dgvDrivingLicenseLocal.Rows.Count;
            lblRecords.Text = RowCount.ToString();

            if (RowCount > 0)
            {
                dgvDrivingLicenseLocal.Columns[0].HeaderText = "L D L Application ID";
                dgvDrivingLicenseLocal.Columns[0].Width = 100;

                dgvDrivingLicenseLocal.Columns[1].HeaderText = "Class Name";
                dgvDrivingLicenseLocal.Columns[1].Width = 185;

                dgvDrivingLicenseLocal.Columns[2].HeaderText = "National No";
                dgvDrivingLicenseLocal.Columns[2].Width = 125;


                dgvDrivingLicenseLocal.Columns[3].HeaderText = "Full Name";
                dgvDrivingLicenseLocal.Columns[3].Width = 200;

                dgvDrivingLicenseLocal.Columns[4].HeaderText = "Application Date";
                dgvDrivingLicenseLocal.Columns[4].Width = 150;

                dgvDrivingLicenseLocal.Columns[5].HeaderText = "Passed Test";
                dgvDrivingLicenseLocal.Columns[5].Width = 100;

                dgvDrivingLicenseLocal.Columns[6].HeaderText = "Application Status";
                dgvDrivingLicenseLocal.Columns[6].Width = 100;


            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Status")
            {
                txtFilter.Visible = false;
                cbStatus.Visible = true;
                cbStatus.Focus();
                cbStatus.SelectedIndex = 0;

            }
            else
            {
                txtFilter.Visible = (cbFilterBy.Text != "None");
                cbStatus.Visible = false;

                txtFilter.Text = "";
                txtFilter.Focus();
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string Filter = "";
            switch (cbFilterBy.SelectedIndex)
            {
                case 1:
                    Filter = "LocalDrivingLicenseApplicationID";
                    break;

                case 2:
                    Filter = "NationalNo";
                    break;

                case 3:
                    Filter = "FullName";
                    break;

                case 4:
                    Filter = "ApplicationStatus";
                    break;
            }

            if ((txtFilter.Text.Trim() == "" || cbFilterBy.Text == "None"))
            {
                DrivingLicenseLocal.DefaultView.RowFilter = "";
                lblRecords.Text = dgvDrivingLicenseLocal.Rows.Count.ToString();
                return;
            }

            if (Filter == "LocalDrivingLicenseApplicationID")
            {
                DrivingLicenseLocal.DefaultView.RowFilter = string.Format("[{0}] = {1}", Filter, txtFilter.Text.Trim());
            }

            if (Filter == "NationalNo" || Filter == "FullName")
            {

                DrivingLicenseLocal.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", Filter, txtFilter.Text.Trim());
            }

            lblRecords.Text = dgvDrivingLicenseLocal.Rows.Count.ToString();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatus.Text == "All")
            {
                DrivingLicenseLocal.DefaultView.RowFilter = "";
                lblRecords.Text = dgvDrivingLicenseLocal.Rows.Count.ToString();
                return;
            }
            else
            {
                DrivingLicenseLocal.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", "Status", cbStatus.Text);
            }
        }

        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseInfo localDrivingLicenseInfo = new frmLocalDrivingLicenseInfo((int)dgvDrivingLicenseLocal.CurrentRow.Cells
                [0].Value);
            localDrivingLicenseInfo.ShowDialog();
            frmLocalDrivingLicenseApplications_Load(null, null);
        }

        private void btnAddNewLocalDrivingApplication_Click(object sender, EventArgs e)
        {
            frmEditLocalDrivingLicense frmEditLocal = new frmEditLocalDrivingLicense();
            frmEditLocal.ShowDialog();

            frmLocalDrivingLicenseApplications_Load(null, null);
        }
        private void editLocalDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditLocalDrivingLicense frmEditLocal = new frmEditLocalDrivingLicense((int)dgvDrivingLicenseLocal.CurrentRow.Cells[0].Value);
            frmEditLocal.ShowDialog();

            frmLocalDrivingLicenseApplications_Load(null, null);
        }

        private void deleteApplicatonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure Delete LocalDrivingLicenseApplications With ID : " + (int)dgvDrivingLicenseLocal.CurrentRow.Cells[0].Value
                , "Note", MessageBoxButtons.OKCancel)==DialogResult.Cancel)
                return;

            int LocalDrivingLicenseApplicationsID = (int)dgvDrivingLicenseLocal.CurrentRow.Cells[0].Value;

            LocalDrivingLicenseApplications applications = LocalDrivingLicenseApplications.
                FindLocalDrivingApplicationByID(LocalDrivingLicenseApplicationsID);                 


            if (applications.Delete())
            {
                MessageBox.Show("Deleted Local Driving License Applications Seccssfuly","Saved",MessageBoxButtons.OK);
                frmLocalDrivingLicenseApplications_Load(null, null);
            }
            else
            {
                MessageBox.Show("Error : This Application Is Found", "erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure do Want to cancel this LocalDrivingLicenseApplications", "Note", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            int LocalDrivingLicenseApplicationsID = (int)dgvDrivingLicenseLocal.CurrentRow.Cells[0].Value;

            LocalDrivingLicenseApplications applications = LocalDrivingLicenseApplications.
                FindLocalDrivingApplicationByID(LocalDrivingLicenseApplicationsID);
            
            if (applications != null)
            {
                if (applications.Cancel())
                {
                    MessageBox.Show("Canceles Local Driving License Applications Seccssfuly", "Saved", MessageBoxButtons.OK);
                    frmLocalDrivingLicenseApplications_Load(null, null);
                }
            }
            else
            {
                MessageBox.Show("Error : This Application Is Found", "erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsApplication_Opening(object sender, CancelEventArgs e)
        {

            int LocalDrivingLicenseApplicationsID=(int) dgvDrivingLicenseLocal.CurrentRow.Cells[0].Value;

            LocalDrivingLicenseApplications localDriving = 
                LocalDrivingLicenseApplications.FindLocalDrivingApplicationByID(LocalDrivingLicenseApplicationsID);

            bool LicenseExists = localDriving.IsLicenseIssued();
            int TotalPassedTest = (int)dgvDrivingLicenseLocal.CurrentRow.Cells[5].Value;

            issueDrivingLicenseToolStripMenuItem.Enabled = (TotalPassedTest==3) && !LicenseExists;
            showLicenseToolStripMenuItem.Enabled = LicenseExists;
            editLocalDrivingLicenseToolStripMenuItem.Enabled = !LicenseExists && (localDriving.ApplicationStatus== Applications.enApplicationStatus.New);
            sechudleTestsToolStripMenuItem.Enabled = !LicenseExists;
            


            cancelApplicationToolStripMenuItem.Enabled = (localDriving.ApplicationStatus == Applications.enApplicationStatus.New)&&
                (localDriving.GetPassedTestCount()==0);
            deleteApplicatonToolStripMenuItem.Enabled = (localDriving.ApplicationStatus == Applications.enApplicationStatus.New) &&
                (localDriving.GetPassedTestCount() == 0);



            bool PassedVisionTest = localDriving.DoesPassTestType(TestTypes.enTestType.VisionTest);
            bool PassedWrittenTest = localDriving.DoesPassTestType(TestTypes.enTestType.writtenTest);
            bool PassedStreetTest = localDriving.DoesPassTestType(TestTypes.enTestType.StreetTest);

            sechudleTestsToolStripMenuItem.Enabled = !(PassedVisionTest && PassedWrittenTest && PassedStreetTest)
                && (localDriving.ApplicationStatus == Applications.enApplicationStatus.New);

            if (sechudleTestsToolStripMenuItem.Enabled)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = !PassedVisionTest;

                scheduleWriteTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;

                scheduleStreetTestToolStripMenuItem.Enabled = !PassedStreetTest && PassedWrittenTest && PassedVisionTest;
            }
        }

        private void _ScheduleTest(TestTypes.enTestType testType)
        {
            frmTestAppointments testAppointment = new frmTestAppointments(
               (int)dgvDrivingLicenseLocal.CurrentRow.Cells[0].Value, testType);
            testAppointment.ShowDialog();

            frmLocalDrivingLicenseApplications_Load(null, null);
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(TestTypes.enTestType.VisionTest);
        }

        private void scheduleWriteTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(TestTypes.enTestType.writtenTest);
        }
        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(TestTypes.enTestType.StreetTest);
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationsID = (int)dgvDrivingLicenseLocal.CurrentRow.Cells[0].Value;

            int LicenseID =
                LocalDrivingLicenseApplications.FindLocalDrivingApplicationByID(LocalDrivingLicenseApplicationsID)
                .GetActiveLicenseID();


            frmDriverLicenseInfo licenseInfo = new frmDriverLicenseInfo(LicenseID);
            licenseInfo.ShowDialog();


        }

        private void issueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIsseueLocalDrivingLicense drivingLicense = new frmIsseueLocalDrivingLicense((int)dgvDrivingLicenseLocal.CurrentRow.Cells
                [0].Value);
            drivingLicense.ShowDialog();

            frmLocalDrivingLicenseApplications_Load(null, null); 

            issueDrivingLicenseToolStripMenuItem.Enabled=false;
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationsID = (int)dgvDrivingLicenseLocal.CurrentRow.Cells[0].Value;

            int PersonID =
                LocalDrivingLicenseApplications.FindLocalDrivingApplicationByID(LocalDrivingLicenseApplicationsID).ApplicantPersonID;

            frmShowPersonLicenseHistory personLicenseHistory = new frmShowPersonLicenseHistory(PersonID);
            personLicenseHistory.ShowDialog();
            frmLocalDrivingLicenseApplications_Load(null, null);

        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
    }
}
