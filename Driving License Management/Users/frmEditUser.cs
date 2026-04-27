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
    public partial class frmEditUser : Form
    {

        int _UserID = -1;
        int _PersonID = -1;
        User _User;
        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode;
        public frmEditUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmEditUser(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
            _Mode = enMode.Update;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpUserInfo.Enabled = true;
                tcAddNewUser.SelectedTab = tcAddNewUser.TabPages["tpUserInfo"];
                return;
            }

            if (  _PersonID != -1)
            {
                if(User.IsExistByPersonID(_PersonID))
                {
                    MessageBox.Show("Selected Person Already has a User", "Change Person", MessageBoxButtons.OK);

                }
                else
                {
                    btnSave.Enabled = true;
                    tpUserInfo.Enabled = true;
                    tcAddNewUser.SelectedTab = tcAddNewUser.TabPages["tpUserInfo"];
                }
            }
            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlFilterPerosnDet1.FilterFocus();

            }
        }

        private void _LoadData()
        {
            _User = User.FindUserByUserID(_UserID);
            ctrlFilterPerosnDet1.EnableFilter = false;

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _UserID ,"User Not Found");
                this.Close();

                return;
            }


            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            chbActive.Checked = _User.IsActive;
            ctrlFilterPerosnDet1.LoadPersonInfo(_User.PersonID);
        }


        private void ctrlFilterPerosnDet1_OnPersonSelect(int obj)
        {
            if (obj != -1)
            {
            _PersonID = obj;

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fileds are not Valide ! ,put the mouse over the red icon",
                    "Validating Error",MessageBoxButtons.OK);
                return;
            }

            _User.PersonID = ctrlFilterPerosnDet1.PersonID;
            _User.Password = txtPassword.Text.Trim();
            _User.UserName = txtUserName.Text.Trim();
            _User.IsActive = chbActive.Checked;


            if (_User.Save())
            {   

                _Mode = enMode.Update;
                lblUserID.Text = _User.UserID.ToString();
                lblMode.Text = "Update User";
                this.Text = "Update User";

                MessageBox.Show("Sccessfuly Edit User","Saved",MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _ResetDefulteValue()
        {
            if (_Mode == enMode.AddNew)
            {
                _User=new User();
                lblMode.Text = "Add New User";
                this.Text = "Add New User";

                tpUserInfo.Enabled = false;
                ctrlFilterPerosnDet1.FilterFocus();
            }
            else
            {
                lblMode.Text = "Update User";
                this.Text = "Update User";

                tpUserInfo.Enabled = true;
                btnSave.Enabled = true;
            }

            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chbActive.Checked = true;
        }
        private void frmEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefulteValue();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
          
            if (string.IsNullOrEmpty(txtUserName.Text) )
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Please Change Your User Name ,It is Use Already");
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }


            if (_Mode == enMode.AddNew)
            {

                if (User.IsExistThisUserName(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "username is used by another user");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                }
                ;
            }
            else
            {
                //incase update make sure not to use anothers user name
                if (_User.UserName != txtUserName.Text.Trim())
                {
                    if (User.IsExistThisUserName(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, null);
                    }
                    ;
                }
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Please Enter Password!");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void frmEditUser_Activated(object sender, EventArgs e)
        {
            ctrlFilterPerosnDet1.FilterFocus();
        }
    }
}
