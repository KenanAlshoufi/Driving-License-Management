using Driving_License_Management.Properties;
using DVDLBusinessLayar;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;


namespace Driving_License_Management
{
    public partial class frmEditPeson : Form
    {
        enum enMode { AddNew = 0, Update = 1 }
        enum enGendor { Male = 0, Female = 1 }

        private enMode Mode;

        private int _PerosnID = -1;

        People _People;

        public delegate void DataBackToForm(object sender, int PersonID);

        public DataBackToForm DataBack;

        public frmEditPeson()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }

 

        public frmEditPeson(int PersonID)
        {
            InitializeComponent();

            _PerosnID = PersonID;
            Mode = enMode.Update;
        }

        private bool _HandlePerosnImage()
        {
            if (_People.ImagePath != pbImage.ImageLocation)
            {

                if (_People.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_People.ImagePath);
                    }
                    catch (IOException)
                    {

                    }
                }
            }
            if (pbImage.ImageLocation != null)
            {
                string SourseImageFile = pbImage.ImageLocation.ToString();
                if (clsUtil.CopyImageToProjectImagesFolder(ref SourseImageFile))
                {
                    pbImage.ImageLocation = SourseImageFile;
                    return true;
                }
                else
                {
                    MessageBox.Show("Erorr Copying Image File", "Erorr", MessageBoxButtons.OK);
                    return false;
                }
            }
           
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fileds are not Valide ! ,put the mouse over the red icon");
                return;
            }

            if (!_HandlePerosnImage())
            {
                return;
            }

            int CountryID = Countries.FindCountryByName(cbNationality.Text).CountryID;


            _People.NationalNo = txtNationalNo.Text;

            _People.FirstName = txtFirstName.Text.Trim();
            _People.SecondName = txtSecondName.Text.Trim();
            _People.ThirdName = txtThirdName.Text.Trim();
            _People.LastName = txtLastName.Text.Trim();
            _People.Email = txtEmail.Text.Trim();
            _People.Phone = txtPhone.Text.Trim();
            _People.Address = txtAddress.Text.Trim();
            _People.NationalityCountryID = CountryID;
            _People.DateOfBirth = dtpDateOfBirth.Value;

            if (rbMale.Checked)
                _People.Gendor = (short)enGendor.Male;
            else
                _People.Gendor = (short)enGendor.Female;



            if (pbImage.ImageLocation != null)
                _People.ImagePath = pbImage.ImageLocation;
            else
                _People.ImagePath = "";


            if (_People.Save())
            {
                MessageBox.Show("Data Saved Successfully.");
                Mode = enMode.Update;
                lblMode.Text = "Edit Person";
                lblPersonID.Text = _People.PersonID.ToString();

                DataBack?.Invoke(this, _People.PersonID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.");

        }

        private void _FillCountriesInComoboBox()
        {
            DataTable Country = Countries.GetAllCountries();
            foreach (DataRow row in Country.Rows)
            {
                cbNationality.Items.Add(row["CountryName"]);
            }
        }

        private void _LoadData()
        {
            _People = People.FindByPersonID(_PerosnID);

            if (_People == null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _PerosnID);
                this.Close();
                return;
            }


            lblPersonID.Text = _PerosnID.ToString();
            txtNationalNo.Text = _People.NationalNo;
            txtFirstName.Text = _People.FirstName;
            txtSecondName.Text = _People.SecondName;
            txtThirdName.Text = _People.ThirdName;
            txtLastName.Text = _People.LastName;
            txtEmail.Text = _People.Email;
            txtPhone.Text = _People.Phone;
            txtAddress.Text = _People.Address;
            dtpDateOfBirth.Value = _People.DateOfBirth;
            cbNationality.SelectedIndex = cbNationality.FindString(_People.InfoCountries.NameCountry);

            if (_People.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;


            if (_People.ImagePath != "")
            {
                pbImage.ImageLocation= _People.ImagePath;
            }
            else
            {
                _SelectPicture();
            }


            lLRemoveImage.Visible = (_People.ImagePath != "");
        }

        private void _ResetDefultValues()
        {
            _FillCountriesInComoboBox();

            if (Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Person";
                _People = new People();
            }
            else
            {
                lblMode.Text = "Update Perosn";
            }

            _SelectPicture();

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);

            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            cbNationality.SelectedIndex = cbNationality.FindString(Countries.FindCountryByName("syria").NameCountry);



        }

        private void AddNewPerson_Load(object sender, EventArgs e)
        {
            _ResetDefultValues();

            if (Mode == enMode.Update)
                _LoadData();

        }

        private void _SelectPicture()
        {
            if (rbMale.Checked)
            {
                pbImage.Image = Resources.office_man;
            }
            else
            {
                pbImage.Image = Resources.woman;
            }
        }





        private void lLSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofdSelectImage.Filter = "Image Files | *.jpg; *.jpeg; *.png; *.gif; *.bmp";
            ofdSelectImage.FilterIndex = 1;
            ofdSelectImage.RestoreDirectory = true;

            if (ofdSelectImage.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file 
                string selectedFilePath = ofdSelectImage.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath); 

                pbImage.ImageLocation=selectedFilePath;
                lLRemoveImage.Visible = true;

            }
        }

        private void lLRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.ImageLocation = null;
            _SelectPicture();
            lLRemoveImage.Visible = false;
        }

        private void ValidateEmptyTextbox(object sender, CancelEventArgs e)
        {
            TextBox temp = ((TextBox)sender);

            if (string.IsNullOrEmpty(temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "This Filed Is requir !");
            }
            else
            {
                errorProvider1.SetError(temp, null);
            }

        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
                return;

            if (!clsValidation.IsValidEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void txtNationalNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This Filed Is requir !");
            }
            else
            {
                btnSave.Enabled = true;
            }

            if (People.IsPersonExist(txtNationalNo.Text) && txtNationalNo.Text.Trim() != _People.NationalNo)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National Nuber is Used for another Person!");
            }
            else
            {
                btnSave.Enabled = true;
            }
        }

        private void rbMale_Click(object sender, EventArgs e)
        {
            if (pbImage.ImageLocation == null)
                pbImage.Image = Resources.office_man;
        }

        private void rbFemale_Click(object sender, EventArgs e)
        {
            if (pbImage.ImageLocation == null)
                pbImage.Image = Resources.woman;
        }
    }
}
