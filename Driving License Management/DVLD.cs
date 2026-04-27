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
    public partial class DVLD : Form
    {
        frmLogin _frmLogin;
        public DVLD(frmLogin frm)
        {
            InitializeComponent();
            _frmLogin = frm;
        }

        private void smiPeople_Click(object sender, EventArgs e)
        {
            frmManagePerson form = new frmManagePerson();
            form.ShowDialog();

        }

        private void smiUsers_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();

            DVLD_Load(null, null);

        }

        private void signouttoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }

        private void ChangePasswordtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChange = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frmChange.ShowDialog();

        }

        private void CurrentUserInfotoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowUserDetails frm = new frmShowUserDetails(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }



        private void ApplicationTypesStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmApplicationTypes applicationTypes = new frmApplicationTypes();
            applicationTypes.ShowDialog();
        }

        private void DVLD_Load(object sender, EventArgs e)
        {
            lblUser.Text =User.NumberOfUsers().ToString();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestTypes frmTestTypes = new frmTestTypes();
            frmTestTypes.ShowDialog();
        }



        private void localDrivingLicneseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditLocalDrivingLicense frm = new frmEditLocalDrivingLicense();
            frm.ShowDialog();
        }

        private void localDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenseApplications frm = new frmManageLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void renewLicneseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicenseApplication RenewLicenseApplication = new frmRenewLicenseApplication();
            RenewLicenseApplication.ShowDialog();


        }

        private void replacementLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacementForDamagedLicense damagedLicense = new frmReplacementForDamagedLicense(); 
            damagedLicense.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowDriversList driversList = new frmShowDriversList();
            driversList.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDetainLicense detainLicense = new frmDetainLicense();
            detainLicense.ShowDialog();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense releaseDetainedLicense = new frmReleaseDetainedLicense();
            releaseDetainedLicense.ShowDialog();
        }

        private void manageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses detainedLicenses = new frmListDetainedLicenses();
            detainedLicenses.ShowDialog();
        }

        private void releseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses listDetainedLicenses =new frmListDetainedLicenses();
            listDetainedLicenses.Show();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueInternationalLicenseApplication internationalLicenseApplication = new frmIssueInternationalLicenseApplication();
            internationalLicenseApplication.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmManageInternationalLicenseApplication manageInternationalLicenseApplication
                = new frmManageInternationalLicenseApplication();

            manageInternationalLicenseApplication.ShowDialog();
        }

       
        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenseApplications frm = new frmManageLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }
    }
}
