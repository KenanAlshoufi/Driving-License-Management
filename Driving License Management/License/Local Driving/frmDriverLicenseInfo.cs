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
    public partial class frmDriverLicenseInfo : Form
    {
        int _licenseID;
        public frmDriverLicenseInfo(int licenseID)
        {
            InitializeComponent();
           _licenseID = licenseID;
        }

      
        private void frmDriverLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseInfo1.LoadLicenceInfo(_licenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
