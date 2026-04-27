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
    public partial class ctrlPersonDet : UserControl
    {

        int _PersonID = -1;

        People _People;
        public ctrlPersonDet()
        {
            InitializeComponent();
        }


        public int PersonID { get {return  _PersonID ; } }

        public People People { get { return _People ; } }

        private void _LoadPersonImage()
        {

            string ImagePath = _People.ImagePath;

            if (ImagePath != "")
            {

                if (File.Exists(ImagePath))
                    pbImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not Find this Image = " + ImagePath, "Erorr", MessageBoxButtons.OK);
            }
            else
            {
                SelectPicture();
            }

        }

        public void ResetDefultValue()
        {
           
            lblPersonID.Text = _PersonID.ToString();
            lblFullName.Text = "";
            lblNationalNo.Text = "";
            lblGendor.Text = "UnKnow";
            lblDateOfBirth.Text = "";
            lblAddress.Text ="";
            lblPhone.Text ="";
            lblEmail.Text = "";
            lblNationality.Text = "";

            pbImage.Image = Resources.office_man;
        }

        private void _FillPersonInfo()
        {
            _PersonID = _People.PersonID;
            lblPersonID.Text = _PersonID.ToString();
            lblFullName.Text = _People.FirstName + " " + _People.SecondName + " " + _People.ThirdName + " " + _People.LastName;
            lblNationalNo.Text = _People.NationalNo;
            lblGendor.Text = (_People.Gendor == 0 ? "Male" : "Female");
            lblDateOfBirth.Text = _People.DateOfBirth.ToString();
            lblAddress.Text = _People.Address;
            lblPhone.Text = _People.Phone;
            lblEmail.Text = _People.Email;
            lblNationality.Text = _People.InfoCountries.NameCountry;

            _LoadPersonImage();
        }
        public void LoadPersonInfo(int PerosnID)
        {
            _People = People.FindByPersonID(PerosnID);

            if (_People == null)
            {
                ResetDefultValue();
                MessageBox.Show("No Person With Person ID = " + PerosnID.ToString(), "Erorr", MessageBoxButtons.OK);
                return;
            }
            _FillPersonInfo();

        }

        public void LoadPersonInfo(string NationalNo)
        {
            _People = People.FindByNationalNo(NationalNo);

            if (_People == null)
            {
                MessageBox.Show("No Person With National No. = " + NationalNo, "Erorr", MessageBoxButtons.OK);
                return;
            }
            _FillPersonInfo();

        }

        private void SelectPicture()
        {
            if (_People.Gendor == 0)
            {
                pbImage.Image = Resources.office_man;
            }
            else
            {
                pbImage.Image = Resources.woman;
            }
        }

        private void llEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmEditPeson person = new frmEditPeson(_PersonID);
            person.ShowDialog();
            LoadPersonInfo(_PersonID);
        }


    }
}
