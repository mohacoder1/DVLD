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

namespace DVLD_Presentation_Layer.Drivers
{
    public partial class frmDriversList : Form
    {
        public frmDriversList()
        {
            InitializeComponent();
        }
        DataTable dtDrivers = clsDrivers.GetAllDriver();
        void _refreashData()
        {
            dgvDrivers.DataSource = dtDrivers;
            lblRecordsCount.Text=dgvDrivers.Rows.Count.ToString();
        }
        private void frmDriversList_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            _refreashData();
            if (dgvDrivers.Rows.Count > 0)
            {
                dgvDrivers.Columns[0].HeaderText = "Driver ID ";
                dgvDrivers.Columns[0].Width = 140;
                dgvDrivers.Columns[1].HeaderText = "Person ID ";
                dgvDrivers.Columns[1].Width = 140;

                dgvDrivers.Columns[2].HeaderText = "National No ";
                dgvDrivers.Columns[2].Width = 120;
                dgvDrivers.Columns[3].HeaderText = "FullName ";
                dgvDrivers.Columns[3].Width = 220;

                dgvDrivers.Columns[4].HeaderText = "CreatedBy Date";
                dgvDrivers.Columns[4].Width = 150;
                dgvDrivers.Columns[5].HeaderText = "No. of Active Licenses";
                dgvDrivers.Columns[5].Width = 140;


            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            /*None
DriverID
PersonID
FullName*/
            string Filter = cbFilterBy.Text;
            if (Filter== "FullName"|| Filter == "NationalNo")
            {
                dtDrivers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", Filter, txtFilter.Text.Trim());
                lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();
            }
            else
                dtDrivers.DefaultView.RowFilter = string.Format("[{0}]={1} ", Filter, txtFilter.Text.Trim());

            lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();


        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.ResetText();
            if (cbFilterBy.SelectedIndex==0)
            {
            txtFilter.Visible = false;
                return;
            }
            txtFilter.Visible = true;
        }

        private void showUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Person=(int)dgvDrivers.CurrentRow.Cells[1].Value;
            frmShowPersonInfocs frm =new frmShowPersonInfocs(Person);
            frm.ShowDialog();
        }

        private void showDrivingLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Person = (int)dgvDrivers.CurrentRow.Cells[1 ].Value;
            frmDriverLicenseHistory frm = new frmDriverLicenseHistory(Person);
            frm.ShowDialog();
        }
    }
}
