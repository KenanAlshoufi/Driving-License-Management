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
    public partial class frmShowPersonLicenseHistory : Form
    {
        int _PersonID;

        public frmShowPersonLicenseHistory()
        {
            InitializeComponent();
        }
        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            this.Text = "Show Person License History";

            if (_PersonID != -1)
            {
                ctrlFilterPerosnDet1.EnableFilter = false;
                ctrlFilterPerosnDet1.LoadPersonInfo(_PersonID);
                ctrlPersonLicenseHistory1.LoadInfoByPersonID(_PersonID);
            }
            else
            {
                ctrlFilterPerosnDet1.EnableFilter = true;
                ctrlFilterPerosnDet1.FilterFocus();
            }
        }

        private void ctrlFilterPerosnDet1_OnPersonSelect(int obj)
        {
            _PersonID =obj;

            if (_PersonID == -1)
            {
                ctrlPersonLicenseHistory1.Clear();  
            }
            else
            {
                ctrlPersonLicenseHistory1.LoadInfoByPersonID(_PersonID);
            }
        }
    }
}
