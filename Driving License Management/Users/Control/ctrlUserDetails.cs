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

namespace Driving_License_Management.Users
{
    public partial class ctrlUserDetails : UserControl
    {
        int _UserID;
        User _User;

        public ctrlUserDetails()
        {
            InitializeComponent();
        }

       
        public User User { get { return _User; } }

        public int UserID
        { 
            get { return _UserID; }
        }

        private void _FillUserInfo()
        {
            ctrlPersonDet1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName;
            lblActive.Text = (_User.IsActive == true ? "Yas" : "No");
        }

        public void LoadUserInfo(int UserID)
        {
            
            _User= User.FindUserByUserID(UserID);


            if (_User == null)
            {
                _ResetUserInfo();
                MessageBox.Show("This is User Not Found!");
                return;
            }

            _FillUserInfo();
        }

      private void _ResetUserInfo()
        {
            ctrlPersonDet1.ResetDefultValue();

            lblUserID.Text = "";
            lblUserName.Text = "";
            lblActive.Text = "";
        }


    }
}
