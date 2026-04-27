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

namespace Driving_License_Management.Tests
{
    public partial class frmAddSchduleTest : Form
    {
        int _LocalDrivingLicenseApplicationID = -1;
        int _TestAppointmentID = -1;
        TestTypes.enTestType _TestTypeID = TestTypes.enTestType.VisionTest;

        public frmAddSchduleTest(int LocalDrivingLicenseApplicationID, TestTypes.enTestType TestTypeID,int TestAppointmentID = -1)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            _TestAppointmentID= TestAppointmentID;
            _TestTypeID= TestTypeID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddSchduleTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.TestTypeID = _TestTypeID;
            ctrlScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _TestAppointmentID);
        }

        private void ctrlScheduleTest1_Load(object sender, EventArgs e)
        {

        }
    }
}
