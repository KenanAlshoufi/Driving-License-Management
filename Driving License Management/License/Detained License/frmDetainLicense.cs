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
using static DVDLBusinessLayar.Licenses;

namespace Driving_License_Management
{
    public partial class frmDetainLicense : Form
    {
        int _LicenseID;
        int _DetainID;


        public frmDetainLicense()
        {
            InitializeComponent();
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


        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Detain the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            _DetainID = ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.Detain(Convert.ToDecimal( txtFineFees.Text),clsGlobal.CurrentUser.UserID);

            if (_DetainID == -1)
            {
                MessageBox.Show("You can not Detain the License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            lblDetainID.Text= _DetainID.ToString();
            MessageBox.Show("The license have become prohibited. " + lblDetainID.Text, "Saved",
               MessageBoxButtons.OK);

            btnDetain.Enabled = false;
            ctrlLocalDrivingLicenseInfoFilter1.FilterEnabled= false;
            txtFineFees.Enabled = false;
            llShowNewLicense.Enabled = true;
        }

        private void ctrlLocalDrivingLicenseInfoFilter1_OnLicenseSelected(int obj)
        {
            _LicenseID = obj;

            llShowLicenseHistory.Enabled = (_LicenseID != -1);


            lblLicneseID.Text = _LicenseID.ToString();

            if (_LicenseID == -1)
            {
                btnDetain.Enabled = false;
                return;
            }

            if (!ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Active, choose an active license."
                   , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                return;
            }

         
          
            if (ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License Already  Detained, choose an active license."
                   , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                return;
            }

            txtFineFees.Enabled = true;
            txtFineFees.Focus();
            btnDetain.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text= DateTime.Now.ToString();
            lblCreateBy.Text= clsGlobal.CurrentUser.UserName;

            txtFineFees.Enabled = false ;
            ctrlLocalDrivingLicenseInfoFilter1.txtLicenseIDFocus();
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Please Enter Your Fees");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFineFees, null);
                
            }
        }
    }
}
