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
    public partial class frmShowPersonDetails : Form
    {
        
        public frmShowPersonDetails(int PerosnID)
        {
            InitializeComponent();
            ctrlPersonDet1.LoadPersonInfo(PerosnID);
        }

        public frmShowPersonDetails(string NationalNo)
        {
            InitializeComponent();
            ctrlPersonDet1.LoadPersonInfo(NationalNo);
        }

    }
}
