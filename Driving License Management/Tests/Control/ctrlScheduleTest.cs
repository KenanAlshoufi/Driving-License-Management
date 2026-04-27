using Driving_License_Management.Properties;
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
using static DVDLBusinessLayar.TestTypes;

namespace Driving_License_Management
{
    public partial class ctrlScheduleTest : UserControl
    {
       
        public ctrlScheduleTest()
        {
            InitializeComponent();
        }

        public enum enMode { AddNew = 0, Update = 1, RetakeTest = 2 }
        private enMode Mode=enMode.AddNew;

        public enum enCreationMode { FirstTimeSchdule =0 , RetakeTestSchdule=1 }
        private enCreationMode _creationMode=enCreationMode.FirstTimeSchdule;

        LocalDrivingLicenseApplications _LocalDrivingLicenseApplications;
        int _LocalDrivingLicenseApplicationID=-1;

        TestAppointment _TestAppointment;
        int _TestAppointmentID=-1;
       
        TestTypes.enTestType _TestTypeID = TestTypes.enTestType.VisionTest;
        public TestTypes.enTestType TestTypeID
        {
            get { return _TestTypeID; }

            set { 
                _TestTypeID = value;

                switch (_TestTypeID)
                {
                    case TestTypes.enTestType.VisionTest:
                        gbTypeTest.Text = "Vision Test";
                        pbImageMode.Image = Resources.eye;
                        break;

                    case TestTypes.enTestType.writtenTest:
                        gbTypeTest.Text = "written Test";
                        pbImageMode.Image = Resources.notes;
                        break;

                    case TestTypes.enTestType.StreetTest:
                        gbTypeTest.Text = "Street Test";
                        pbImageMode.Image = Resources.driving_test;
                        break;

                }

            }
        }


        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (Mode == enMode.AddNew && _LocalDrivingLicenseApplications.IsThereAnActiveScheduledTest(_TestTypeID))
            {
                lblError.Text = "Person Already have an active appointment for this test";
                btnSave.Enabled = false;
                dtpDateAppointment.Enabled = false;
                return false;
            }
            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            //if appointment is locked that means the person already sat for this test
            //we cannot update locked appointment
            if (_TestAppointment.IsLocked)
            {
                lblError.Visible = true;
                lblError.Text = "Person already sat for the test, appointment loacked.";
                dtpDateAppointment.Enabled = false;
                btnSave.Enabled = false;
                return false;

            }
            else
                lblError.Visible = false;

            return true;
        }


        private bool _HandlePrviousTestConstraint()
        {
            switch (_TestTypeID)
            {
                case TestTypes.enTestType.VisionTest:
                    lblError.Visible= false;
                    return true;

                    case TestTypes.enTestType.writtenTest:
                    if (!_LocalDrivingLicenseApplications.DoesPassTestType(TestTypes.enTestType.VisionTest))
                    {
                        lblError.Text = "Cannot Sechule, Vision Test should be passed first";
                        lblError.Visible = true;
                        btnSave.Enabled = false;
                        dtpDateAppointment.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblError.Visible = false;
                        btnSave.Enabled = true;
                        dtpDateAppointment.Enabled = true;
                    }

                    return true;

                case TestTypes.enTestType.StreetTest:
                    //we check if pass Written 2.
                    if (!_LocalDrivingLicenseApplications.DoesPassTestType(TestTypes.enTestType.writtenTest))
                    {
                        lblError.Text = "Cannot Sechule, Written Test should be passed first";
                        lblError.Visible = true;
                        btnSave.Enabled = false;
                        dtpDateAppointment.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblError.Visible = false;
                        btnSave.Enabled = true;
                        dtpDateAppointment.Enabled = true;
                    }


                    return true;

            }
            return true;
        }
        

        public void LoadInfo(int LocalDrivingLicenseApplicationID,int TestAppointmentID=-1)
        {
            if (TestAppointmentID == -1)
                Mode = enMode.AddNew;
            else 
                Mode = enMode.Update;



            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID=TestAppointmentID;


            _LocalDrivingLicenseApplications = LocalDrivingLicenseApplications.
                FindLocalDrivingApplicationByID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplications == null)
            {
                MessageBox.Show("Error : This Local Driving License Applications Is not Exist", "Error", MessageBoxButtons.OK);
                btnSave.Enabled = false;
                return;
            }

            if (_LocalDrivingLicenseApplications.DoesAttendTestType(_TestTypeID))
            {
                _creationMode = enCreationMode.RetakeTestSchdule;
            }
            else
            {
                _creationMode = enCreationMode.FirstTimeSchdule;
            }

            if (_creationMode == enCreationMode.RetakeTestSchdule)
            {
                lblRApplicationFees.Text = ApplicationTypes.FindApplicationTypesByID((int)Applications.enApplicationTypes.RetakeTest).ApplicationFees.ToString();
                gbRetakeTestInfo.Enabled = true;
                lblModeTestAppointment.Text = "Schdule Retake Test";
                lblRAppID.Text = "0";
            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lblRApplicationFees.Text = "0";
               lblModeTestAppointment.Text = "Schdule Test";
                lblRAppID.Text = "N/A";
            }

            lblDLAPP.Text = _LocalDrivingLicenseApplicationID.ToString();
            lblClass.Text = _LocalDrivingLicenseApplications.LicenseClassInfo.ClassName;
            lblName.Text = _LocalDrivingLicenseApplications.PerosnFullName;
            lblTrial.Text = _LocalDrivingLicenseApplications.TotalTrialsPerTest(_TestTypeID).ToString();



            if (Mode == enMode.AddNew)
            {
                lblTestFees.Text = TestTypes.FindTestTypesByID(_TestTypeID).TestTypeFees.ToString();
                dtpDateAppointment.MinDate = DateTime.Now;
                lblRAppID.Text = "N/A";

                _TestAppointment=new TestAppointment();
            }
            else
            {
                if (!_LoadTestAppointmentInfo())
                {
                    return;
                }
            }

            lblTotalFess.Text=(Convert.ToSingle(lblTestFees.Text)+ Convert.ToSingle(lblRApplicationFees.Text)).ToString();

            if (!_HandleActiveTestAppointmentConstraint())
            {
                return ;
            }
            if (!_HandleAppointmentLockedConstraint())
            {
                return;
            }

            if (!_HandlePrviousTestConstraint())
                return;
        }


        private bool _LoadTestAppointmentInfo()
        {
            
            _TestAppointment = TestAppointment.FindTestAppointmentByID(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                btnSave.Enabled = false;
                MessageBox.Show("Error : This TestAppointment Is not Exist", "Error", MessageBoxButtons.OK);
                return false;
            }

            lblTestFees.Text = _TestAppointment.PaidFees.ToString();

            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
            {
                dtpDateAppointment.MinDate=DateTime.Now;
                dtpDateAppointment.Value = DateTime.Now;
            }
            else
            {
                dtpDateAppointment.MinDate=_TestAppointment.AppointmentDate;
                dtpDateAppointment.Value = _TestAppointment.AppointmentDate;
            }

           

            if (_TestAppointment.RetakeTestApplicationID == -1)
            {
                lblRAppID.Text = "N/A";
                lblRApplicationFees.Text = "0";

            }
            else
            {
                lblRApplicationFees.Text =_TestAppointment.RetakeTestApplicationInfo.PaidFees.ToString();
                lblModeTestAppointment.Text = "Schedule Retake Test";
                gbRetakeTestInfo.Enabled = true;
                lblRAppID.Text =_TestAppointment.RetakeTestApplicationID.ToString(); 
            }
             return true;
        }


        private bool _HandleRetakeTest()
        {
            if (Mode==enMode.AddNew && _creationMode==enCreationMode.RetakeTestSchdule)
            {
                Applications applications = new Applications();


                applications.ApplicantPersonID = _LocalDrivingLicenseApplications.ApplicantPersonID;
                applications.ApplicationDate = DateTime.Now;
                applications.LastStatusDate = DateTime.Now;
                applications.ApplicationStatus = Applications.enApplicationStatus.Completed;
                applications.ApplicationTypeID = (int)Applications.enApplicationTypes.RetakeTest;
                applications.PaidFees = ApplicationTypes.FindApplicationTypesByID((int)Applications.enApplicationTypes.RetakeTest).ApplicationFees;
                applications.CreatedByUserID = clsGlobal.CurrentUser.UserID;
               
                
                if (!applications.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Error : Edit Retake Test Application", "Error", MessageBoxButtons.OK);
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = applications.ApplicationID;
            }


            return true;
        }
            
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeTest())
            {
                return;
            }

            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.AppointmentDate = dtpDateAppointment.Value;
            _TestAppointment.LocalDrivingLicenseApplicationID = Convert.ToInt32(lblDLAPP.Text);
            _TestAppointment.PaidFees = Convert.ToDecimal(lblTestFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
          

            if (_TestAppointment.Save())
            {
                Mode = enMode.Update;
                MessageBox.Show("Edit Test Appointment Seccessfully", "Saved", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Error : Edit Test Appointment", "Error", MessageBoxButtons.OK);
            }

        }
    }
}
