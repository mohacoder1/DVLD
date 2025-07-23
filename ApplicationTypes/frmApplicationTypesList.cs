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

namespace DVLD_Presentation_Layer.People.ApplicationTypes
{
    public partial class frmApplicationTypesList : Form
    {
        public frmApplicationTypesList()
        {
            InitializeComponent();
        }
         
        private void frmApplicationTypesList_Load(object sender, EventArgs e)
        {
            _RefreashData();
            if (dgvApplicationTypes.Rows.Count>0)
            {
                dgvApplicationTypes.Columns[0].HeaderText = "Application ID";
                dgvApplicationTypes.Columns[0].Width = 157; 
                dgvApplicationTypes.Columns[1].HeaderText = "Application Title";
                dgvApplicationTypes.Columns[1].Width = 600; 
                dgvApplicationTypes.Columns[2].HeaderText = "Application Fees";
                dgvApplicationTypes.Columns[2].Width = 200;

            }

        }
        void _RefreashData()
        {
            dgvApplicationTypes.DataSource = clsApplicationTypes.GetAll();

        }
        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditApplicationTypes editApplication = new frmAddEditApplicationTypes((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);  
            editApplication.ShowDialog();
            _RefreashData();
        }
    }
}
