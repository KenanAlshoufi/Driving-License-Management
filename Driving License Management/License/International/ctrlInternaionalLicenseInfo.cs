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

namespace Driving_License_Management
{
    public partial class ctrlInternaionalLicenseInfo : UserControl
    {
        public ctrlInternaionalLicenseInfo()
        {
            InitializeComponent();
        }

        InternaionalLicense _ILicense;
        int _ILicenseID;

        public int ILicenseID
        {
            get { return _ILicenseID; }
        }

        public InternaionalLicense SelectedILicenseInfo
        { get { return _ILicense; } }

        void ResetDefulteValue()
        {
            lblILicense.Text = "[????]";
            lblLicenceID.Text = "[????]";
            lblFullName.Text = "[????]";
            lblDriverId.Text = "[????]";
            lblGendor.Text = "[????]";
            lblIsActive.Text = "[????]";
            lblExpartionDate.Text = "[????]";
            lblDateofBirth.Text = "[????]";
            lblIssueDate.Text = "[????]";
            lblNationalNo.Text = "[????]";
        }

        private void _LoadPersonImage()
        {
            if (_ILicense.DriverInfo.PersonInfo.Gendor == 0)
                pbImage.Image = Resources.office_man;
            else
            {
                pbImage.Image = Resources.woman;

            }

            string ImagePath = _ILicense.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbImage.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void LoadInterbationalLicenceInfo(int ILicenseID)
        {
            _ILicenseID = ILicenseID;

            _ILicense = InternaionalLicense.Find(ILicenseID);

            if (_ILicense == null)
            {
                MessageBox.Show("Error : This Person not have International License", "Error", MessageBoxButtons.OK);
                _ILicenseID = -1;
                ResetDefulteValue();
                return;
            }

            lblILicense.Text = _ILicense.InternationalLicenseID.ToString();
            lblApplicationID.Text = _ILicense.ApplicationID.ToString();
            lblLicenceID.Text = _ILicense.IssuedUsingLocalLicenseID.ToString();
            lblFullName.Text = _ILicense.DriverInfo.PersonInfo.FullName;
            lblDriverId.Text = _ILicense.DriverID.ToString();
            lblGendor.Text = _ILicense.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Famale";
            lblIsActive.Text = _ILicense.IsActive ? "Yas" : "No";
            lblExpartionDate.Text = clsFormat.DateToShort(_ILicense.ExpirationDate);
            lblIssueDate.Text = clsFormat.DateToShort(_ILicense.IssueDate);
            lblDateofBirth.Text = clsFormat.DateToShort(_ILicense.DriverInfo.PersonInfo.DateOfBirth);
            lblNationalNo.Text = _ILicense.DriverInfo.PersonInfo.NationalNo;
           

            _LoadPersonImage();

        }

    }
}
