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
using static System.Net.Mime.MediaTypeNames;

namespace Driving_License_Management
{
    public partial class frmEditTestType : Form
    {

        TestTypes.enTestType _TestTypeID= TestTypes.enTestType.VisionTest;
        TestTypes _TestTypes;
        public frmEditTestType(TestTypes.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }

            _TestTypes.TestTypeID =_TestTypeID;
            _TestTypes.TestTypeTitle = txtTestType.Text.Trim();
            _TestTypes.TestTypeDescription = txtTestDes.Text.Trim();
            _TestTypes.TestTypeFees = decimal.Parse(txtTestFees.Text.Trim());

            if (_TestTypes.UpdateTestTypes())
            {
                MessageBox.Show("Sccessfuly Edit Test Type", "Saved", MessageBoxButtons.OK);
                return;
            }
            else
            {
                MessageBox.Show("Error :Filed Edit Test Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            
            _TestTypes = TestTypes.FindTestTypesByID(_TestTypeID);

            if (_TestTypes != null)
            {
                lblTestTypeID.Text = ((int)_TestTypeID).ToString();
                txtTestType.Text = _TestTypes.TestTypeTitle.ToString();
                txtTestDes.Text = _TestTypes.TestTypeDescription.ToString();
                txtTestFees.Text = _TestTypes.TestTypeFees.ToString();
            }
            else
            {
                MessageBox.Show("", "Error",MessageBoxButtons.OK);
            }
        }

        private void txtTestDes_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTestDes.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestDes, "Description cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtTestDes, null);
            }
            ;
        }

        private void txtTestType_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTestType.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestType, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtTestType, null);
            }
            ;
        }

        private void txtTestFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTestFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtTestFees, null);

            }
            ;


            if (!clsValidation.IsNumber(txtTestFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtTestFees, null);
            }
            ;
        }
    }
}
