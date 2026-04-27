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
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        int _ApplicationID = -1;

        Applications _ApplicationsBasic;

        public int ApplicationID
        {
            get { return _ApplicationID; }
        }

        private void _FillApplicationInfo()
        {
            _ApplicationID= _ApplicationsBasic.ApplicationID;
            lblApplicationID.Text = _ApplicationsBasic.ApplicationID.ToString();
            lblFees.Text = _ApplicationsBasic.PaidFees.ToString();
            lblFullName.Text = _ApplicationsBasic.PersonInfo.FullName.ToString();
            lblDate.Text =clsFormat.DateToShort( _ApplicationsBasic.ApplicationDate);
            lblStatusDate.Text = clsFormat.DateToShort(_ApplicationsBasic.LastStatusDate);
            lblUserName.Text = _ApplicationsBasic.CreateByUserInfo.UserName;
            lblType.Text = _ApplicationsBasic.ApplicationTypeInfo.ApplicationTypeTitle;
            lblStatus.Text = _ApplicationsBasic.StatusText;
        }

        public void ResetApplicationInfo()
        {
            _ApplicationID = -1;

            lblApplicationID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblType.Text = "[????]";
            lblFees.Text = "[????]";
            lblFullName.Text = "[????]";
            lblDate.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblUserName.Text = "[????]";
            llViewPersonInfo.Enabled = false;
        }

        public void LoadApplicationBasicInfo(int ApplicationID)
        {
            _ApplicationsBasic = Applications.FindBaseApplication(ApplicationID);


            if (_ApplicationsBasic == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("Error : ", "Error", MessageBoxButtons.OK);
                return;
            }

            _FillApplicationInfo();
           
           
        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonDetails frmShow = new frmShowPersonDetails(_ApplicationsBasic.ApplicantPersonID);
            frmShow.ShowDialog();

            LoadApplicationBasicInfo(_ApplicationID);
        }
    }
}
