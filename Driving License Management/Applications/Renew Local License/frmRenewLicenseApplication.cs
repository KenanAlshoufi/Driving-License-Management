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
    public partial class frmRenewLicenseApplication : Form
    {

        int NewLicenseID;
        Licenses _licensesOld;
        public frmRenewLicenseApplication()
        {
            InitializeComponent();
        }


        private void LoadRenewInfo()
        {
            _licensesOld = ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo;


            lblExpartionDate.Text = DateTime.Now.AddYears(_licensesOld.
                licenseClassInfo.DefaultValidityLength).ToString();

            lblLicenseFees.Text = _licensesOld.licenseClassInfo.ClassFees.ToString();
            lblTotalFees.Text = (decimal.Parse(lblApplicationFees.Text) + decimal.Parse(lblLicenseFees.Text)).ToString();

            lblOldLicneseID.Text = ctrlLocalDrivingLicenseInfoFilter1.LicenseID.ToString();

            txtNotes.Text = ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.Notes.ToString();
        }


        private void frmRenewLicenseApplication_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingLicenseInfoFilter1.txtLicenseIDFocus();


            lblApplicationDate.Text =clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text =lblApplicationDate.Text;

            lblExpartionDate.Text = "????";
            lblApplicationFees.Text = ApplicationTypes.FindApplicationTypesByID(
                (int)Applications.enApplicationTypes.RenewDrivingLicenseService).ApplicationFees.ToString();
            lblCreateBy.Text=clsGlobal.CurrentUser.UserID.ToString();


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ctrlLocalDrivingLicenseInfoFilter1.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlLocalDrivingLicenseInfoFilter1.txtLicenseIDFocus();
                return;
            }

            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            Licenses Newlicense = _licensesOld.RenewLicense(txtNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);

           
            if (Newlicense == null)
            {
                MessageBox.Show("You can not Renew the License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblRLAPP.Text = (Newlicense.ApplicationID).ToString();

            NewLicenseID = Newlicense.LicenseID;
            lblRenewLicenseID.Text = NewLicenseID.ToString();
            MessageBox.Show("The license has been renewed New License ID : " + lblRenewLicenseID.Text, "Saved",
                MessageBoxButtons.OK);
            
            
            btnSave.Enabled = false;
            ctrlLocalDrivingLicenseInfoFilter1.FilterEnabled = false;
            llShowNewLicense.Enabled = true;


        }

        private void ctrlLocalDrivingLicenseInfoFilter1_OnLicenseSelected(int obj)
        {
           int _LicenseID = obj;

            llShowLicenseHistory.Enabled = (_LicenseID != -1 );


            if (_LicenseID == -1)
            {
                btnSave.Enabled = false;
                return;
            }


            LoadRenewInfo();

            if (!ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared .","Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            if (!ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                   , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            btnSave.Enabled = true;

           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory personLicenseHistory = new frmShowPersonLicenseHistory(ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            personLicenseHistory.ShowDialog();
        }

        private void llShowNewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo drivingLicenseInfo = new frmDriverLicenseInfo(NewLicenseID);
            drivingLicenseInfo.ShowDialog();
        }
    }
}
