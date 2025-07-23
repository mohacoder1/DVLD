using DVLD_Business_Layer; 
using DVLD_Presentation_Layer.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer
{
    public partial class frmPeopleList : Form
    {

         // Get All People To DataTable
         static DataTable _dtAllPeople=clsPeople.GetAllPeople();

        // Make subset of The DataTable
        DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName",
            "LastName", "DateOfBirth", "Gender", "Nationality", "Phone","Email");
        public frmPeopleList()
        {
            InitializeComponent();
        }

        private void frmPeopleList_Load(object sender, EventArgs e)
        {
            _Refreash();
            cbFilterBy.SelectedIndex = 0;

            if (dgvPeople.Rows.Count>0)
            {
                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width =78;

                dgvPeople.Columns[1].HeaderText = "National No";
                dgvPeople.Columns[1].Width = 90;

                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[3].HeaderText = "Second Name";
                dgvPeople.Columns[4].HeaderText = "Third Name";
                dgvPeople.Columns[5].HeaderText = "Last Name";

                dgvPeople.Columns[6].HeaderText = "Date Of Birth";
                dgvPeople.Columns[7].Width = 100;

                dgvPeople.Columns[7].HeaderText = "Gender";
                dgvPeople.Columns[8].HeaderText = "Nationality";
                dgvPeople.Columns[9].HeaderText = "Phone";

                dgvPeople.Columns[10].HeaderText = "Email";
               
            }
        }
        void _Refreash()
        {

            dgvPeople.DataSource = _dtPeople;
            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.ShowDialog();
            _Refreash();
        }
        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAddEditPerson frm = new frmAddEditPerson();
            frm.ShowDialog();
            _Refreash();

        }
        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAddEditPerson frm = new frmAddEditPerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _Refreash();

        }
        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You sure you want to Delete this Person ? ", "Delete Message", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Information)==DialogResult.Yes)
            {
                if (clsPeople.DeletePerson((int)dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("this Person  was Deleted Successfully!  ", "Done !",
                    MessageBoxButtons.OK);
                    _Refreash();
                }
                    else 
                    {
                        MessageBox.Show("This Person was NOT Deleting because there are som data Linked with it  ", "ERROR! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
                    
            }

        }
        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfocs frm = new frmShowPersonInfocs((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (cbFilterBy.SelectedIndex==1)
            {
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
           string FilterColumn=cbFilterBy.Text;
            if (txtFilter.Text.Trim()==""||cbFilterBy.Text=="None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "PersonID")
            { 
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}]={1} ",FilterColumn,txtFilter.Text.Trim());

            }
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());

            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();

        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = (cbFilterBy.SelectedIndex != 0);
            txtFilter.Focus();
            txtFilter.ResetText();
        }

        private void dgvPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
