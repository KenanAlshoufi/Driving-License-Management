using Driving_License_Management.Properties;
using DVDLBusinessLayar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Management.License.Local_Driving.Control
{
    public partial class ctrlDrivingLicenseInfo : UserControl
    {

        
        Licenses _License;
        int _LicenseID;


        public ctrlDrivingLicenseInfo()
        {
            InitializeComponent();
        }
        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public Licenses SelectedLicenseInfo
        { get { return _License; } }

        void ResetDefulteValue()
        {
            lblLicenceID.Text ="[????]";
            lblFullName.Text = "[????]";
            lblDriverId.Text = "[????]";
            lblGendor.Text = "[????]";
            lblIsActive.Text = "[????]";
            lblExpartionDate.Text = "[????]";
            lblIssueDate.Text = "[????]";
            lblDateofBirth.Text = "[????]";
            lblIssueReason.Text = "[????]";

            lblIsDetained.Text = "[????]";

            lblNationalNo.Text = "[????]";
            lblClass.Text = "[????]";
            lblNotes.Text = "[????]";
        }

        private void _LoadPersonImage()
        {
            if (_License.DriverInfo.PersonInfo.Gendor == 0)
                pbImage.Image = Resources.office_man;
            else
            {
                pbImage.Image = Resources.woman;

            }

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbImage.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void LoadLicenceInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
         
            this.Text = "Driver License Info";

            _License = Licenses.FindLicenseByID(LicenseID);

            if (_License == null)
            {
                MessageBox.Show("Error : This Person not have Local Driving License", "Error", MessageBoxButtons.OK);
                _LicenseID = -1;
                ResetDefulteValue();
                return;
            }


            lblLicenceID.Text = _License.LicenseID.ToString();
            lblFullName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblDriverId.Text = _License.DriverID.ToString();
            lblGendor.Text = _License.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Famale";
            lblIsActive.Text = _License.IsActive ? "Yas" : "No";
            lblExpartionDate.Text =clsFormat.DateToShort(_License.ExpirationDate);
            lblIssueDate.Text = clsFormat.DateToShort(_License.IssueDate);
            lblDateofBirth.Text = clsFormat.DateToShort(_License.DriverInfo.PersonInfo.DateOfBirth);
            lblIssueReason.Text = _License.IssueReasonText;

            lblIsDetained.Text = clsDetain.IsLicenseDetain(_LicenseID)  ? "Yas" : "No";

            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblClass.Text = _License.licenseClassInfo.ClassName;

            lblNotes.Text = (_License.Notes!="" ? _License.Notes : "N/A");

            _LoadPersonImage();

        }

    }
}
