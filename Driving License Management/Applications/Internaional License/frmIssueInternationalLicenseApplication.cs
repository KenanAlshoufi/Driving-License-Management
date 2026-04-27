using DVDLBusinessLayar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVDLBusinessLayar.Applications;

namespace Driving_License_Management
{
    public partial class frmIssueInternationalLicenseApplication : Form
    {
        int _InternationalLicenseID = -1;
        int _LicenseID = -1;
        public frmIssueInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Are you sure you want to Issue International license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            //ApplicantPersonID, ApplicationDate,
            // ApplicationTypeID, Convert.ToByte(ApplicationStatus), LastStatusDate, PaidFees, CreatedByUserID

            InternaionalLicense internaionalLicense = new InternaionalLicense();
            internaionalLicense.ApplicantPersonID = ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            internaionalLicense.ApplicationDate=DateTime.Now;
            internaionalLicense.ApplicationTypeID =(int) Applications.enApplicationTypes.NewInternationalLicense;
            internaionalLicense.ApplicationStatus= Applications.enApplicationStatus.Completed;
            internaionalLicense.LastStatusDate= DateTime.Now;
            internaionalLicense.PaidFees = ApplicationTypes.FindApplicationTypesByID((int)Applications.enApplicationTypes.NewInternationalLicense).ApplicationFees;

                internaionalLicense.DriverID=ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.DriverID;
                internaionalLicense.IssuedUsingLocalLicenseID= ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.LicenseID;
               internaionalLicense.IssueDate=DateTime.Now;
            internaionalLicense.ExpirationDate = DateTime.Now.AddYears(1);
               internaionalLicense.IsActive=true;
            internaionalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

          
            if (!internaionalLicense.Save())
            {
                MessageBox.Show("You can not Release the License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _InternationalLicenseID = internaionalLicense.InternationalLicenseID;
            lblInternationalLicenseID.Text = internaionalLicense.InternationalLicenseID.ToString();
            lblILAPP.Text= internaionalLicense.ApplicationID.ToString();


            MessageBox.Show("Done Issue International License." + lblInternationalLicenseID.Text, "Saved",
               MessageBoxButtons.OK);

            ctrlLocalDrivingLicenseInfoFilter1.FilterEnabled = false;
            llShowNewLicense.Enabled = true;
            btnIssue.Enabled = false;
        }


        private void ctrlLocalDrivingLicenseInfoFilter1_OnLicenseSelected(int obj)
        {
            _LicenseID = obj;


            llShowLicenseHistory.Enabled = (_LicenseID != -1);


            if (_LicenseID == -1)
            {
                btnIssue.Enabled = false;
                return;
            }


            if (ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is Detained ."
                   , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }

            if (!ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Active ."
                   , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }

            if (InternaionalLicense.GetActiveInternationalLicenseIDByDriverID(ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo
                .DriverID)!=-1)
            {
                MessageBox.Show("Selected License have International Licence."
                  , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }

            if (ctrlLocalDrivingLicenseInfoFilter1.SelectedLicenseInfo.licenseClassInfo.LicenseClassID != 3)
            {
                MessageBox.Show("Selected License Is not Class 3 - Ordinary driving license  ."
                  , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }

            lblApplicationDate.Text = DateTime.Now.ToString();
            lblApplicationFees.Text = ApplicationTypes.FindApplicationTypesByID
                  ((int)Applications.enApplicationTypes.NewInternationalLicense).ApplicationFees.ToString();


            lblLocalLicneseID.Text = ctrlLocalDrivingLicenseInfoFilter1.LicenseID.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblExpartionDate.Text = DateTime.Now.AddYears(1).ToString();
            lblCreateBy.Text = clsGlobal.CurrentUser.UserName;

            
            btnIssue.Enabled = true;
        }

        private void llShowNewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalLicenseInfo internationalLicenseInfo=new frmInternationalLicenseInfo(_InternationalLicenseID);
            internationalLicenseInfo.ShowDialog();

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
