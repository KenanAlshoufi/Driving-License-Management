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
    public partial class frmChangePassword : Form
    {
        int _UserID = -1;
        User user;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void _ResetDefulteValue()
        {
            txtConfirmPassword.Text = "";
            txtNewPassword.Text = "";
            txtCurrentPassword.Text = "";

            txtCurrentPassword.Focus();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefulteValue();

            user = User.FindUserByUserID(_UserID);

            if (user == null)
            {
                MessageBox.Show("Could not Find User with id =" +_UserID,"Error",MessageBoxButtons.OK);
                return;
            }

            ctrlUserDetails1.LoadUserInfo(_UserID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fildes are not valide ! ,put the mouse of icon","Erorr",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (User.ChangePassword(_UserID, txtNewPassword.Text.Trim()))
            {
                MessageBox.Show("Password Changeded Sccessfuly!","Saved",MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("An error occured , Password did not Change.!", "Error", MessageBoxButtons.OK);

            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
          
            if ( txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Please Enter Your Confirm Password");
                return;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Please Enter Your Password");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }

            string PasswordAfterHash = User.ComputeHash(txtCurrentPassword.Text.Trim());

            if (user.Password != PasswordAfterHash)
            {

                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Please Enter Your Password");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }


        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "Please Enter Your Confirm Password");
                return ;
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            }

            if (txtNewPassword.Text == txtCurrentPassword.Text)
            {
                errorProvider1.SetError(txtNewPassword, "It is match the Current Password Try another Password!");
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, "");

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
