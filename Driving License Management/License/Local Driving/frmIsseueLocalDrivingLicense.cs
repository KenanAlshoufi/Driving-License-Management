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
using static System.Net.Mime.MediaTypeNames;

namespace Driving_License_Management
{
    public partial class frmIsseueLocalDrivingLicense : Form
    {
        int _LocalDrivingLicenseApplicationID = -1;
        LocalDrivingLicenseApplications _localDrivingLicense;
        public frmIsseueLocalDrivingLicense(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseID = _localDrivingLicense.IssueLicenseForTheFirtTime(txtNotes.Text, clsGlobal.CurrentUser.UserID);


            if (LicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully with License ID = " + LicenseID.ToString(),
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("License Was not Issued ! ",
                 "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIsseue_ocalDrivingLicense_Load(object sender, EventArgs e)
        {
            txtNotes.Focus();
            this.Text = "Isseue Local Driving License";

            _localDrivingLicense = LocalDrivingLicenseApplications.FindLocalDrivingApplicationByID(_LocalDrivingLicenseApplicationID);

            if (_localDrivingLicense == null)
            {

                MessageBox.Show("No Applicaiton with ID=" + _LocalDrivingLicenseApplicationID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            if (!_localDrivingLicense.PassedAllTests())
            {

                MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            int LicenseID = _localDrivingLicense.GetActiveLicenseID();

            if (LicenseID != -1)
            {

                MessageBox.Show("Person already has License before with License ID=" + LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;

            }

            ctrlLocalDrivingLiceneseApplicationInfo1.LoadLocalDrivingLicenseApplicationInfoByID(_LocalDrivingLicenseApplicationID);

        }


    }
}
