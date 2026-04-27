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
    public partial class frmApplicationTypes : Form
    {
        public frmApplicationTypes()
        {
            InitializeComponent();
        }

       

        private void frmApplicationTypes_Load(object sender, EventArgs e)
        {
             DataTable _GetAllApplicationType = ApplicationTypes.GetAllApplicationTypes();
            dgvApplicationType.DataSource = _GetAllApplicationType;

           lblRowCount.Text= dgvApplicationType.Rows.Count.ToString() ;


            if (dgvApplicationType.Rows.Count > 0)
            {
                dgvApplicationType.Columns[0].HeaderText = "ApplicationType ID";
                dgvApplicationType.Columns[0].Width = 150;

                dgvApplicationType.Columns[1].HeaderText = "ApplicationType Title";
                dgvApplicationType.Columns[1].Width = 300;

                dgvApplicationType.Columns[2].HeaderText = "ApplicationType Fees";
                dgvApplicationType.Columns[2].Width = 150;
            }
        }

        
        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationType frmEdit =new frmEditApplicationType((int)dgvApplicationType.CurrentRow.Cells[0].Value);
            frmEdit.ShowDialog();
            frmApplicationTypes_Load(null,null);
        }
    }
}
