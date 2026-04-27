using Driving_License_Management.Local_Driving_License.Control;
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
    public partial class frmReplacementForDamagedLicense : Form
    {

        int _NewLicenseID;
        Licenses.enIssueReason _IssueReason;

        public frmReplacementForDamagedLicense()
        {
            InitializeComponent();
        }

        private void frmReplacementForDamagedLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);

            ctrlLocalDrivingLicenseInfoFilter1.txtLicenseIDFocus();
            lblCreateBy.Text = clsGlobal.CurrentUser.UserID.ToString();
            rbDamagedLicense.Checked = true;

            lblApplicationFees.Text = ApplicationTypes.FindApplicationTypesByID(
                (int)Applications.enApplicationTypes.ReplacementforaDamagedDrivingLicense).ApplicationFees.ToString();
            this.Text = "Replacement For Damaged License";
            _IssueReason = Licenses.enIssueReason.ReplacementforDamaged;


        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            
            Licenses Newlicense = ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.Replace(_IssueReason, clsGlobal.CurrentUser.UserID);


            if (Newlicense == null)
            {
                MessageBox.Show("You can not Renew the License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblRLAPP.Text = (Newlicense.ApplicationID).ToString();

            _NewLicenseID = Newlicense.LicenseID;
            lblRenewLicenseID.Text = _NewLicenseID.ToString();
            MessageBox.Show("The license has been renewed New License ID : " + lblRenewLicenseID.Text, "Saved",
                MessageBoxButtons.OK);


            btnIssueReplacement.Enabled = false;
            gbRepalcement.Enabled = false;
            ctrlLocalDrivingLicenseInfoFilter1.FilterEnabled = false;
            llShowNewLicense.Enabled = true;

        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            
                lblApplicationFees.Text = ApplicationTypes.FindApplicationTypesByID(
                (int)Applications.enApplicationTypes.ReplacementforaDamagedDrivingLicense).ApplicationFees.ToString();

                lblIssueMode.Text = "            Replacement For Damaged License";
                this.Text = "Replacement For Damaged License";
                _IssueReason = Licenses.enIssueReason.ReplacementforDamaged;   
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblIssueMode.Text = "        Replacement For Lost License";

            this.Text = "Replacement For Lost License";
            lblApplicationFees.Text = ApplicationTypes.FindApplicationTypesByID(
               (int)Applications.enApplicationTypes.ReplacementforaLostDrivingLicense).ApplicationFees.ToString();

            _IssueReason = Licenses.enIssueReason.ReplacementforLost;
        
        }
        private void llShowNewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo drivingLicenseInfo = new frmDriverLicenseInfo(_NewLicenseID);
            drivingLicenseInfo.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory personLicenseHistory = new frmShowPersonLicenseHistory(ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            personLicenseHistory.ShowDialog();
        }

        private void ctrlLocalDrivingLicenseInfoFilter1_OnLicenseSelected(int obj)
        {
            int _LicenseID = obj;

            llShowLicenseHistory.Enabled = (_LicenseID != -1);


            if (_LicenseID == -1)
            {
                btnIssueReplacement.Enabled = false;
                return;
            }


            lblOldLicneseID.Text = ctrlLocalDrivingLicenseInfoFilter1.LicenseID.ToString();

         
            if (!ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                   , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;
            }

            btnIssueReplacement.Enabled = true;
        }

     
    }
}
