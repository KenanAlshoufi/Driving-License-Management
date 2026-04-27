using DVDLBusinessLayar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Management
{
    public partial class frmReleaseDetainedLicense : Form
    {
        int _LicenseID=-1;

        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        public frmReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;

            ctrlLocalDrivingLicenseInfoFilter1.LoadLicenseInfo(_LicenseID);
            ctrlLocalDrivingLicenseInfoFilter1.FilterEnabled = false;
        }

       
        private void btnRelease_Click(object sender, EventArgs e)
        {
            int ApplicationID = -1;
            if (MessageBox.Show("Are you sure you want to Release the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            bool IsRelease = ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.ReleaseDetainedLicense
                (clsGlobal.CurrentUser.UserID,ref ApplicationID);



            if (!IsRelease)
            {
                MessageBox.Show("You can not Release the License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblRLAPP.Text = ApplicationID.ToString();



            btnRelease.Enabled = false;

            MessageBox.Show("The ban on the License has been lifted. " + lblDetainID.Text, "Saved",
               MessageBoxButtons.OK);

            ctrlLocalDrivingLicenseInfoFilter1.FilterEnabled = false;
            llShowNewLicense.Enabled = true;

        }

        private void ctrlLocalDrivingLicenseInfoFilter1_OnLicenseSelected(int obj)
        {
            _LicenseID = obj;


            llShowLicenseHistory.Enabled = (_LicenseID != -1);


            if (_LicenseID == -1)
            {
                btnRelease.Enabled = false;
                return;
            }


           

            if (!ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is not Detained ."
                   , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRelease.Enabled = false;
                return;
            }


            lblApplicationFees.Text = ApplicationTypes.FindApplicationTypesByID
                  ((int)Applications.enApplicationTypes.ReleaseDetainedDrivingLicsense).ApplicationFees.ToString();


            lblLicneseID.Text = ctrlLocalDrivingLicenseInfoFilter1.LicenseID.ToString();
            lblDetainID.Text = ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.DetainedInfo.DetainID.ToString();

            lblCreateBy.Text = ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.DetainedInfo.CreatedByUserInfo.UserName;
            lblDetainDate.Text = ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.DetainedInfo.DetainDate.ToString();
            lblFineFees.Text = ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.DetainedInfo.FineFees.ToString();
            lblTotalFees.Text = (ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.DetainedInfo.FineFees + decimal.Parse(lblApplicationFees.Text)).ToString();

            btnRelease.Enabled = true;
        }

        private void llShowNewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo drivingLicenseInfo = new frmDriverLicenseInfo(_LicenseID);
            drivingLicenseInfo.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory personLicenseHistory = new frmShowPersonLicenseHistory(ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            personLicenseHistory.ShowDialog();
        }


     
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
