using DVDLBusinessLayar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Driving_License_Management
{
    public partial class frmLogin : Form
    {
        public frmLogin()   
        {
            InitializeComponent();

           
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            TextBox temp = (TextBox)sender;

            if (string.IsNullOrEmpty(temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "Please Enter UserName And Password!");
            }
            else
            {
                errorProvider1.SetError(temp, null);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                cbRememberme.Checked = true;
            }
            else
                cbRememberme.Checked = false;

           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
           
            clsFormat.SetRoundedRegion(this, 60);
            clsFormat.SetRoundedRegion(btnLogin, 25);
            clsFormat.SetRoundedRegion(txtUserName, 10);
            clsFormat.SetRoundedRegion(txtPassword, 10);
            clsFormat.SetRoundedRegion(pictureBox5, 60);

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }

            User user = User.FindUserByUserNameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            if (user != null)
            {
                if (cbRememberme.Checked)
                {
                    clsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                {
                    clsGlobal.RememberUsernameAndPassword("", "");
                }

                if (!user.IsActive)
                {
                    txtUserName.Focus();
                    MessageBox.Show("Your Accont Is not Active ,Contact Admin.", "In Active",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                clsGlobal.CurrentUser = user;
                this.Hide();

                DVLD frm = new DVLD(this);
                frm.ShowDialog();
            }

            else
            {
                MessageBox.Show("User Name Or Password Is Not Currect", "Error", MessageBoxButtons.OK);
                return;
            }

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            Process.Start(new ProcessStartInfo
            {
                FileName = "www.linkedin.com/in/kenanal-shoufi",
                UseShellExecute = true
            });
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/KenanAlshoufi",
                UseShellExecute = true
            });
        }

       
    }
    }

