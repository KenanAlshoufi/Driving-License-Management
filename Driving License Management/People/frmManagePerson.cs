using DVDLBusinessLayar;
using System;
using System.Data;
using System.Windows.Forms;

namespace Driving_License_Management
{
    public partial class frmManagePerson : Form
    {
        public frmManagePerson()
        {
            InitializeComponent();
        }

        private static  DataTable GetAllPerson = People.GetAllPesron();

        private DataTable _GetPerson = GetAllPerson.DefaultView.ToTable(false, "PersonID",
            "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName", "GendorCaption",
            "DateOfBirth", "CountryName", "Phone", "Email");


        private void ManagePerson_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            dgvPerson.DataSource = _GetPerson;
            int RowCount = dgvPerson.Rows.Count;
            lblRowCount.Text = RowCount.ToString();

            if (RowCount > 0)
            {
                dgvPerson.Columns[0].HeaderText = "Person ID";
                dgvPerson.Columns[0].Width =100 ;

                dgvPerson.Columns[1].HeaderText = "National No";
                dgvPerson.Columns[1].Width = 110;

                dgvPerson.Columns[2].HeaderText = "First Name";
                dgvPerson.Columns[2].Width = 120;

                dgvPerson.Columns[3].HeaderText = "Second Name";
                dgvPerson.Columns[3].Width = 120;

                dgvPerson.Columns[4].HeaderText = "Third Name";
                dgvPerson.Columns[4].Width = 120;

                dgvPerson.Columns[5].HeaderText = "Last Name";
                dgvPerson.Columns[5].Width = 120;

                dgvPerson.Columns[6].HeaderText = "Gendor";
                dgvPerson.Columns[6].Width = 70;

                dgvPerson.Columns[7].HeaderText = "DateOfBirth";
                dgvPerson.Columns[7].Width = 120;

                dgvPerson.Columns[8].HeaderText = "Nationality";
                dgvPerson.Columns[8].Width = 110;

                dgvPerson.Columns[9].HeaderText = "Phone";
                dgvPerson.Columns[9].Width = 100;

                dgvPerson.Columns[10].HeaderText = "Email";
                dgvPerson.Columns[10].Width = 120;
            }
        }

        private void FilterType()
        {
            string Filter = "";

            switch (cbFilterBy.SelectedIndex)
            {

                case 0:
                    Filter = "None";
                    break;
                case 1:
                    Filter = "PersonID" ;
                    break;

                case 2:
                    Filter = "NationalNo";
                    break;

                case 3:
                    Filter = "FirstName";
                    break;

                case 4:
                    Filter = "SecondName";
                    break;

                case 5:
                    Filter = "ThirdName";
                    break;

                case 6:
                    Filter = "LastName";
                    break;

                case 7:
                    Filter = "CountryName";
                    break;

                case 8:
                    Filter = "GendorCaption";
                    break;

                case 9:
                    Filter = "Phone";
                    break;

                case 10:
                    Filter = "Email";
                    break;
            }

            if (txtFilter.Text.Trim()=="" ||Filter == "None")
            {
                _GetPerson.DefaultView.RowFilter = "";
                lblRowCount.Text = dgvPerson.Rows.Count.ToString();
                return;
            }

            if (Filter == "PersonID")
            {
                _GetPerson.DefaultView.RowFilter = string.Format("[{0}] = {1}", Filter, txtFilter.Text.Trim());
            }
            else
            {
                _GetPerson.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", Filter, txtFilter.Text.Trim());
            }
            lblRowCount.Text = dgvPerson.Rows.Count.ToString();
        }

       

        private void _RefreshData()
        {
            if (cbFilterBy.Text != "None")
            {
                txtFilter.Text = "";
            }
            GetAllPerson = People.GetAllPesron();

        _GetPerson = GetAllPerson.DefaultView.ToTable(false, "PersonID",
            "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName", "GendorCaption",
            "DateOfBirth", "CountryName", "Phone", "Email");

            dgvPerson.DataSource = _GetPerson;
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmEditPeson person = new frmEditPeson();
            person.ShowDialog();
            _RefreshData();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            FilterType();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible= (cbFilterBy.Text != "None");
            if (txtFilter.Visible)
            { 
                txtFilter.Text = "";
                txtFilter.Focus();
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonDetails showDetails = new frmShowPersonDetails((int)dgvPerson.CurrentRow.Cells[0].Value);
            showDetails.ShowDialog();
            _RefreshData();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditPeson person = new frmEditPeson();
            person.ShowDialog();
            _RefreshData();
        }

        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditPeson person = new frmEditPeson((int)dgvPerson.CurrentRow.Cells[0].Value);
            person.ShowDialog();
            _RefreshData();
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure Delete this Person ? ","Confirm",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                People Person= People.FindByPersonID((int)dgvPerson.CurrentRow.Cells[0].Value);
                if (People.DeletePerson(Person.PersonID))
                {
                    MessageBox.Show("Sccessfuly Delete This Person");
                    if (Person.ImagePath != "")
                        System.IO.File.Delete(Person.ImagePath);
                    _RefreshData();
                }
                else
                {
                    MessageBox.Show("Filed Delete This Person Because it have Relationship!");
                }
            }
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((string)dgvPerson.CurrentRow.Cells[11].Value != "")
                MessageBox.Show("Send Emal to " + (string)dgvPerson.CurrentRow.Cells[11].Value);
        }

        private void callPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if((string)dgvPerson.CurrentRow.Cells[10].Value!="")
            MessageBox.Show("Call Phone Emal to " + (string)dgvPerson.CurrentRow.Cells[10].Value);
        }

        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
            frmSearchPerson searchPerson = new frmSearchPerson();
            searchPerson.ShowDialog();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
    }
}
