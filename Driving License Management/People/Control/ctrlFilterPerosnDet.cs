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
using System.Xml.Serialization;

namespace Driving_License_Management
{
    public partial class ctrlFilterPerosnDet : UserControl
    {
        public ctrlFilterPerosnDet()
        {
            InitializeComponent();
        }

        public event Action<int> OnPersonSelect;

        protected virtual void PersonSelect(int PersonID)
        {
            Action<int> handler = OnPersonSelect;
            if (handler != null)
            {
                handler(PersonID);
            }
        }

        bool _AddPerson=true;
        public bool AddPerson
        {
            get { return _AddPerson; }
            set
            {
                _AddPerson = value;
                btnAddPerson.Enabled = _AddPerson;
            }
        }

        bool _EnableFilter = true;
        public bool EnableFilter
        {
            get {return _EnableFilter;}
            set {  _EnableFilter = value; 
                gbFilter.Enabled = _EnableFilter;
            }
        }

        int _PersonID = -1;
        public int PersonID
        {
            get { return ctrlPersonDet1.PersonID; }
           
        }

        public People SelectedPersonInfo
        {
            get { return ctrlPersonDet1.People; }
        }

        public void FilterFocus()
        {
            txtFilter.Focus();
        }

        private void FindNow()
        {

            switch (cbFilterBy.SelectedIndex)
            {
                case 0:
                    ctrlPersonDet1.LoadPersonInfo(int.Parse(txtFilter.Text));
                    break;
                case 1:
                    ctrlPersonDet1.LoadPersonInfo(txtFilter.Text);
                    break;
            }
                
            if (OnPersonSelect!=null&& EnableFilter)
            {
                PersonSelect(ctrlPersonDet1.PersonID);
            }

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = "";
        }

        public void LoadPersonInfo(int PersonID)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilter.Text = PersonID.ToString();
            FindNow();
        }
        private void DataBackEvent(object sender,int PersonID)
        {
           
            cbFilterBy.SelectedIndex = 0;
            txtFilter.Text = PersonID.ToString();
            ctrlPersonDet1.LoadPersonInfo(PersonID);
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmEditPeson AddNewPerson = new frmEditPeson();
            AddNewPerson.DataBack += DataBackEvent;
            AddNewPerson.ShowDialog();

        }

        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please Enter txt Filter to Search Person");
            }
            FindNow();
           
        }

        private void ctrlFilterPerosnDet_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilter.Focus();
        }

        
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearchPerson.PerformClick();
            }

            if (cbFilterBy.SelectedIndex == 0)
            {
                e.Handled=!char.IsDigit(e.KeyChar) &&!char.IsControl(e.KeyChar);
            }
        }
    }
}
