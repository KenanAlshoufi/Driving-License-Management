using Driving_License_Management.Properties;
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
using static DVDLBusinessLayar.TestTypes;

namespace Driving_License_Management
{
    public partial class frmTakeTest : Form
    {

        int _TestAppointmentID = -1;
        int _TestID = -1;

        TestTypes.enTestType _testType = TestTypes.enTestType.VisionTest;
        clsTest Tests;




        public frmTakeTest(int TestAppointmentID, TestTypes.enTestType testType)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            _testType = testType;
        }


        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlSchduledTest1.TestTypeID = _testType;

            ctrlSchduledTest1.LoadInfo(_TestAppointmentID);

            if (ctrlSchduledTest1.TestAppointmentID == -1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;


            int _TestID = ctrlSchduledTest1.TestID;
            if (_TestID != -1)
            {
                Tests = clsTest.FindTestByID(_TestID);

                if (Tests.TestResult)
                    rbPassed.Checked = true;
                else
                    rbFail.Checked = true;

                txtNotes.Text = Tests.Notes;


                lblUserMessage.Visible = true;
                rbFail.Enabled = false;
                rbPassed.Enabled = false;
            }

            else
                Tests = new clsTest();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                        "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No
               )
            {
                return;
            }

            Tests.TestAppointmentID = _TestAppointmentID;
            Tests.TestResult = rbPassed.Checked;
            Tests.Notes = txtNotes.Text.Trim();
            Tests.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (Tests.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                this.Close ();
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
