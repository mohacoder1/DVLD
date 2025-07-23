using DVLD_Business_Layer;
using DVLD_Presentation_Layer.ApplicationTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Test_Types
{
    public partial class frmTestTypesList : Form
    {
        public frmTestTypesList()
        {
            InitializeComponent();
        }
        void _RefreashData()
        {
            dgvTestTypes.DataSource = clsTestTypes.GetAll();
        }
        private void frmTestTypesList_Load(object sender, EventArgs e)
        {
            _RefreashData();

            dgvTestTypes.Columns[0].HeaderText = "Test Type ID";
            dgvTestTypes.Columns[0].Width = 100;

            dgvTestTypes.Columns[1].HeaderText = "Test Type Title";
            dgvTestTypes.Columns[1].Width = 150;

            dgvTestTypes.Columns[2].HeaderText = "Test Type Description";
            dgvTestTypes.Columns[2].Width = 630;

            dgvTestTypes.Columns[3].HeaderText = "Fees";
            dgvTestTypes.Columns[3].Width = 100;
        }

        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestTypes edit = new frmEditTestTypes((int)dgvTestTypes.CurrentRow.Cells[0].Value);
            edit.ShowDialog();
            _RefreashData();
        }
    }
}
