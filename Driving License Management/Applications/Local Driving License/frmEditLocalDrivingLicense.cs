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

namespace Driving_License_Management
{
    public partial class frmEditLocalDrivingLicense : Form
    {

        int _LocalDrivingLicenseApplicationID = -1;
        int _SelectedPersonID = -1;

        LocalDrivingLicenseApplications _LDLApplications;

        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode;
        public frmEditLocalDrivingLicense()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmEditLocalDrivingLicense(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpNewApplication.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpNewApplication"];
                return;
            }

            if (_SelectedPersonID != -1)
            {
                tpNewApplication.Enabled = true;
                btnSave.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpNewApplication"];
            }
            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlFilterPerosnDet1.FilterFocus();
            }
        }

        private void _FillAllLicenseClass()
        {
            DataTable data= LicenseClass.GetAllLicenseClass();
            foreach (DataRow row in data.Rows)
            {
                cbLicenseClass.Items.Add(row[0]);
            }
        }

        private void _ResetDefulteValues()
        {
            _FillAllLicenseClass();

            if (_Mode==enMode.AddNew)
            {
                _LDLApplications = new LocalDrivingLicenseApplications();
                lblMode.Text = "New Local Driving License";
                this.Text = "New Local Driving License";
                tpNewApplication.Enabled = false;
                ctrlFilterPerosnDet1.FilterFocus();

                cbLicenseClass.SelectedIndex = 2;
                lblApplicationFees.Text = (ApplicationTypes.FindApplicationTypesByID((int)Applications.enApplicationTypes.NewLocalDrivingLicenseService).ApplicationFees).ToString();
                lblUserName.Text = clsGlobal.CurrentUser.UserName;
                lblApplicationDate.Text = DateTime.Now.ToString();
            }
            else
            {
                lblMode.Text = "Update Local Driving License";
                this.Text = "Update Local Driving License";
                tpNewApplication.Enabled = true;
                btnSave.Enabled =true;
            }

        }

        private void _LoadData()
        {
            ctrlFilterPerosnDet1.EnableFilter = false;

            _LDLApplications = LocalDrivingLicenseApplications.FindLocalDrivingApplicationByID(_LocalDrivingLicenseApplicationID);

            if (_LDLApplications == null)
            {
                MessageBox.Show("Error: No Application With ID = "+_LocalDrivingLicenseApplicationID);
                return;
            }

            ctrlFilterPerosnDet1.LoadPersonInfo(_LDLApplications.ApplicantPersonID);
           
            lblLDLApplicationID.Text=_LDLApplications.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationFees.Text =_LDLApplications.PaidFees.ToString();
            lblApplicationDate.Text= _LDLApplications.ApplicationDate.ToShortDateString();
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(LicenseClass.FindLicenseByID(_LDLApplications.LicenseClassID).ClassName);
            lblUserName.Text=User.FindUserByUserID(_LDLApplications.CreatedByUserID).UserName;

        }

        private void frmLocalDrivingLicense_Load(object sender, EventArgs e)
        {

            _ResetDefulteValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlFilterPerosnDet1_OnPersonSelect(int obj)
        {
            if (obj != -1)
            {
                _SelectedPersonID = obj;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int LicenseClassID = LicenseClass.FindLicenseByName(cbLicenseClass.Text).LicenseClassID;

            int ActiveApplicationID = Applications.GetActiveApplicationIDForLicneseClass(_SelectedPersonID, Applications.enApplicationTypes.NewLocalDrivingLicenseService, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }


            if (Licenses.ISLicenseExistByPersonID(ctrlFilterPerosnDet1.PersonID, LicenseClassID))
            {

                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            short MinimumAllowedAge = LicenseClass.FindLicenseByID(LicenseClassID).MinimumAllowedAge;

            if (MinimumAllowedAge > (DateTime.Now.Year-ctrlFilterPerosnDet1.SelectedPersonInfo.DateOfBirth.Year))
            {
                MessageBox.Show("Minimum Allowed Age for " + cbLicenseClass.Text + " is " + MinimumAllowedAge, "Error", MessageBoxButtons.OK);
                return;
            }




            _LDLApplications.ApplicantPersonID = _SelectedPersonID;
            _LDLApplications.ApplicationTypeID =(int) Applications.enApplicationTypes.NewLocalDrivingLicenseService;
            _LDLApplications.ApplicationDate = DateTime.Parse(lblApplicationDate.Text);
            _LDLApplications.LastStatusDate = DateTime.Now;
            _LDLApplications.PaidFees = ApplicationTypes.FindApplicationTypesByID(_LDLApplications.ApplicationTypeID).ApplicationFees;
            _LDLApplications.ApplicationStatus=Applications.enApplicationStatus.New;
            _LDLApplications.CreatedByUserID=clsGlobal.CurrentUser.UserID;
            _LDLApplications.LicenseClassID = LicenseClassID;

           
           if (_LDLApplications.Save())
            {
                
                lblLDLApplicationID.Text = _LDLApplications.LocalDrivingLicenseApplicationID.ToString();
                _Mode = enMode.Update;
                lblMode.Text = "Update Local Driving License";
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK);

               
            }
           else
            {
                MessageBox.Show("Error : Data Is not Saved Application Local Driving License", "Error", MessageBoxButtons.OK);
            }


        }

        private void frmLocalDrivingLicense_Activated(object sender, EventArgs e)
        {
            ctrlFilterPerosnDet1.FilterFocus();
        }
    }
}
