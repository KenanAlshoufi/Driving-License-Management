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
    public partial class frmInternationalLicenseInfo : Form
    {
        int _ILicenseID;
        public frmInternationalLicenseInfo(int ILicenseID)
        {
            InitializeComponent();
            _ILicenseID = ILicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            this.Text = "International License Info";

            ctrlInternaionalLicenseInfo1.LoadInterbationalLicenceInfo(_ILicenseID);
        }
    }
}
