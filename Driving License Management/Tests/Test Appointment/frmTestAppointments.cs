using Driving_License_Management.Properties;
using Driving_License_Management.Tests;
using DVDLBusinessLayar;
using System;
using System.Windows.Forms;

namespace Driving_License_Management
{
    public partial class frmTestAppointments : Form
    {
        int _LocalDrivingLicenseApplicationID = -1;
        TestTypes.enTestType _testType = TestTypes.enTestType.VisionTest;


        public frmTestAppointments(int LocalDrivingLicenseApplicationID, TestTypes.enTestType testType)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _testType = testType;

        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_testType)
            {
                case TestTypes.enTestType.VisionTest:
                    lblModeTestAppointment.Text = "Vision Test Appointment";
                    this.Text = "Vision Test Appointment";
                    btnAddAppointment.BackgroundImage = Resources.eye;
                    pbImageMode.Image = Resources.eye;
                    break;

                case TestTypes.enTestType.writtenTest:
                    lblModeTestAppointment.Text = "written Test Appointment";
                    this.Text = "written Test Appointment";
                    btnAddAppointment.BackgroundImage = Resources.notes;
                    pbImageMode.Image = Resources.notes;
                    break;

                case TestTypes.enTestType.StreetTest:
                    lblModeTestAppointment.Text = "Street Test Appointment";
                    this.Text = "Street Test Appointment";
                    btnAddAppointment.BackgroundImage = Resources.driving_test;
                    pbImageMode.Image = Resources.driving_test;
                    break;
            }
        }

        private void frmVisionTestAppointments_Load(object sender, EventArgs e)
        {

            _LoadTestTypeImageAndTitle();

            ctrlLocalDrivingLiceneseApplicationInfo1.LoadLocalDrivingLicenseApplicationInfoByID(_LocalDrivingLicenseApplicationID);


            dgvVisionTestAppointment.DataSource = TestAppointment.
                GetAllTestAppointmentByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID, _testType);


            lblRecords.Text = dgvVisionTestAppointment.Rows.Count.ToString();

            if (dgvVisionTestAppointment.Rows.Count > 0)
            {
                dgvVisionTestAppointment.Columns[0].HeaderText = "Appointment ID";
                dgvVisionTestAppointment.Columns[0].Width = 150;

                dgvVisionTestAppointment.Columns[1].HeaderText = "Appointment Date";
                dgvVisionTestAppointment.Columns[1].Width = 200;

                dgvVisionTestAppointment.Columns[2].HeaderText = "Paid Fees";
                dgvVisionTestAppointment.Columns[2].Width = 150;

                dgvVisionTestAppointment.Columns[3].HeaderText = "Is Locked";
                dgvVisionTestAppointment.Columns[3].Width = 100;
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            LocalDrivingLicenseApplications localDrivingLicense = LocalDrivingLicenseApplications.
                FindLocalDrivingApplicationByID(_LocalDrivingLicenseApplicationID);

           
            if (localDrivingLicense.IsThereAnActiveScheduledTest(_testType))
            {
                MessageBox.Show("Person Already have an active Appoinment for This test!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTest LastTest = localDrivingLicense.GetLastTestPerTestType(_testType);


            if (LastTest ==null)
            {
                frmAddSchduleTest schduleTest =new frmAddSchduleTest(_LocalDrivingLicenseApplicationID,_testType);
                schduleTest.ShowDialog();

                frmVisionTestAppointments_Load(null,null);
                return;
            }

            if (LastTest.TestResult)
            {
                MessageBox.Show("This Person Is already Passed this test ");
                return;
            }

            frmAddSchduleTest testAppointment = new frmAddSchduleTest(LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID, _testType);
            testAppointment.ShowDialog();

            frmVisionTestAppointments_Load(null, null);

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddSchduleTest testAppointment = new frmAddSchduleTest(_LocalDrivingLicenseApplicationID, _testType, (int)dgvVisionTestAppointment.CurrentRow.Cells[0].Value);
            testAppointment.ShowDialog();

            frmVisionTestAppointments_Load(null, null);

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest takeTest = new frmTakeTest((int)dgvVisionTestAppointment.CurrentRow.Cells[0].Value, _testType);
            takeTest.ShowDialog();

            frmVisionTestAppointments_Load(null, null);
        }
    }
}
