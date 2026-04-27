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
    public partial class frmLocalDrivingLicenseInfo : Form
    {
        int _LocalDrivingLicenseApplicationID = -1;
        public frmLocalDrivingLicenseInfo(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void frmLocalDrivingLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingLiceneseApplicationInfo1.LoadLocalDrivingLicenseApplicationInfoByID(_LocalDrivingLicenseApplicationID);
        }
    }
}
