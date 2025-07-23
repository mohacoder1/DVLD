using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Applications.DetainAndReleaseLicenses
{
    public partial class frmManageDetainedLicense : Form
    {
        public frmManageDetainedLicense()
        {
            InitializeComponent();
        }
        void _refreashData()
        {
            dgvApplicationTypes.DataSource = clsDetainedLicenses.GetAll();

        }
        private void frmManageDetainedLicense_Load(object sender, EventArgs e)
        {
            _refreashData();
        }

        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID=(int)dgvApplicationTypes.CurrentRow.Cells[1].Value;
            frmDetainLicenseApplication frmDetainLicenseApplication = new frmDetainLicenseApplication(LicenseID);
            frmDetainLicenseApplication.ShowDialog();
        }
    }
}
