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
    public partial class frmSearchPerson : Form
    {
        public delegate void DataBackToForm(object sender, int PersonID);

        public DataBackToForm DataBack;

        public frmSearchPerson()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, ctrlFilterPerosnDet1.PersonID);
        }

        //طريقة ثاني
        //private void ctrlFilterPerosnDet1_OnPersonSelect(int obj)
        //       {
        //           DataBack?.Invoke(this, obj);
        //       }


    }
}
