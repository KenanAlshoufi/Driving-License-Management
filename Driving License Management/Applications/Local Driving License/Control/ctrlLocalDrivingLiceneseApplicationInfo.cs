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
    public partial class ctrlLocalDrivingLiceneseApplicationInfo : UserControl
    {


        LocalDrivingLicenseApplications _localDrivingLicense;

        int _LocalDrivingLicenseApplicationID = -1;

        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID;}
        }

        public ctrlLocalDrivingLiceneseApplicationInfo()
        {
            InitializeComponent();
        }


        private void _FillApplicationInfo()
        {
            _LocalDrivingLicenseApplicationID = _localDrivingLicense.LocalDrivingLicenseApplicationID;
            lblDlApp.Text = _localDrivingLicense.LocalDrivingLicenseApplicationID.ToString();
            lblLiceneseClass.Text = _localDrivingLicense.LicenseClassInfo.ClassName;
            lblPassedTests.Text = _localDrivingLicense.GetPassedTestCount().ToString()+"/3";
            ctrlApplicationBasicInfo1.LoadApplicationBasicInfo(_localDrivingLicense.ApplicationID);
            llShowLicenseInfo.Enabled = (Licenses.GetActiveLicenseIDByPersonID(_localDrivingLicense.ApplicantPersonID,
                _localDrivingLicense.LicenseClassID) !=-1);
        }

        public void ResetApplicationInfo()
        {
            _LocalDrivingLicenseApplicationID = -1;
            ctrlApplicationBasicInfo1.ResetApplicationInfo();
            lblDlApp.Text = "[????]";
            lblLiceneseClass.Text = "[????]";
            lblPassedTests.Text= "[????]";
            llShowLicenseInfo.Enabled = false;
            
        }


        public  void LoadLocalDrivingLicenseApplicationInfoByID(int LocalDrivingLicenseApplicationID)
        {
            _localDrivingLicense = LocalDrivingLicenseApplications.FindLocalDrivingApplicationByID(LocalDrivingLicenseApplicationID);


            if (_localDrivingLicense == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("Error : No Application With ApplicationID = "+ LocalDrivingLicenseApplicationID, "Error", MessageBoxButtons.OK);
                return;
            }

            _FillApplicationInfo();
        }

        public void LoadLocalDrivingLicenseApplicationInfoByApplicationID(int ApplicationID)
        {
            _localDrivingLicense = LocalDrivingLicenseApplications.FindLocalDrivingApplicationByApplicationID(ApplicationID);


            if (_localDrivingLicense == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("Error : No Application With ApplicationID = " + ApplicationID,"Error", MessageBoxButtons.OK);
                return;
            }

            _FillApplicationInfo();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int LicenseID =
               LocalDrivingLicenseApplications.FindLocalDrivingApplicationByID(_LocalDrivingLicenseApplicationID)
               .GetActiveLicenseID();

            frmDriverLicenseInfo licenseInfo = new frmDriverLicenseInfo(LicenseID);
            licenseInfo.ShowDialog();
        }

        
    }
}
