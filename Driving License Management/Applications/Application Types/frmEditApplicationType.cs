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
    public partial class frmEditApplicationType : Form
    {
        int _ApplicationID = -1;
        ApplicationTypes _Application;
        public frmEditApplicationType(int ApplicationID)
        {
            InitializeComponent();
            _ApplicationID = ApplicationID;
        }


        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            lblApplicationID.Text = _ApplicationID.ToString();
            _Application = ApplicationTypes.FindApplicationTypesByID(_ApplicationID);

            if (_Application != null)
            {
                txtApplicationType.Text = _Application.ApplicationTypeTitle.ToString();
                txtApplicationFees.Text = _Application.ApplicationFees.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }

            _Application.ApplicationTypeID = _ApplicationID;
            _Application.ApplicationTypeTitle = txtApplicationType.Text.Trim();
            _Application.ApplicationFees =decimal.Parse( txtApplicationFees.Text.Trim());

            if (_Application.Save())
            {
                MessageBox.Show("Sccessfuly Edit Application Type", "Saved", MessageBoxButtons.OK);
                return ;
            }
            else
            {
                MessageBox.Show("Error :Filed Edit Application Type", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void txtApplicationType_Validating(object sender, CancelEventArgs e)
        {
           
            if (string.IsNullOrEmpty(txtApplicationType.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtApplicationType, "Please Enter Application Title!");
            }
            else
            {
                errorProvider1.SetError(txtApplicationType, null);
            }
        }

        private void txtApplicationFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtApplicationFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtApplicationFees, "Please Enter ApplicationFees!");
            }
            else
            {
                errorProvider1.SetError(txtApplicationFees, null);
            }

            if (!clsValidation.IsNumber(txtApplicationFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtApplicationFees, "Please Enter ApplicationFees!");
            }
            else
            {
                errorProvider1.SetError(txtApplicationFees, null);
            }
        }
    }
}
