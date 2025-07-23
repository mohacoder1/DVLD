using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Licenses.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Drivers.controls
{
    public partial class ctrlDriverLicenses : UserControl
    {
        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }
        clsDrivers _Driver;
        int _DriverID = -1;
        DataTable _dtDriverLocalLicensesHistory;
        DataTable _dtDriverInternationalLicensesHistory;
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void LoadInfo(int DriverID)
        {
            _DriverID = DriverID;
            _Driver = clsDrivers.Find(DriverID);
            if (_Driver == null)
            {
                MessageBox.Show("This Driver With Given ID Doesnt Exists", "Not Found", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            _LoadLocalLicensesInfo();
            _LoadInternationallLicensesInfo();
        }
        public void LoadInfoByPerson(int PersonID)
        {
            
            _Driver = clsDrivers.FindByPerson(PersonID);
            _DriverID =_Driver. DriverID;
            if (_Driver == null)
            {
                MessageBox.Show("This Driver With Given ID Doesnt Exists", "Not Found", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            _LoadLocalLicensesInfo();
            _LoadInternationallLicensesInfo();
        }
        public void _LoadLocalLicensesInfo()
        {
            
            _dtDriverLocalLicensesHistory = clsLicenses.GetDriverLicenses(_DriverID);
            dgvLocal.DataSource = _dtDriverLocalLicensesHistory;
            lblLocalRecordsCount.Text = _dtDriverLocalLicensesHistory.Rows.Count.ToString();
            if (dgvLocal.Rows.Count > 0)
            {
                dgvLocal.Columns[2].HeaderText = "License Class";
                dgvLocal.Columns[2].Width = 230;

                dgvLocal.Columns[3].Width = 150;
                dgvLocal.Columns[4].Width = 150;
                dgvLocal.Columns[5].HeaderText = "CreatedBy UserID";
                dgvLocal.Columns[5].Width = 120;
            }

        }
        public void _LoadInternationallLicensesInfo()
        {
            _dtDriverInternationalLicensesHistory = clsLicenses.GetDriverLicenses(_DriverID);
            dgvInternational.DataSource = _dtDriverInternationalLicensesHistory;
            lblRecordsCount.Text = _dtDriverInternationalLicensesHistory.Rows.Count.ToString();

            if (dgvInternational.Rows.Count > 0)
            {
                dgvInternational.Columns[2].HeaderText = "License Class";
                dgvInternational.Columns[2].Width = 230;

                dgvInternational.Columns[3].Width = 150;
                dgvInternational.Columns[4].Width = 150;
                dgvInternational.Columns[5].HeaderText = "CreatedBy UserID";
                dgvInternational.Columns[5].Width = 120;
            }
        }
        private void ctrlDriverLicenses_Load(object sender, EventArgs e)
        {
           
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID=(int)dgvLocal.CurrentRow.Cells[0].Value;
            frmShowDriverLicenseInfo ShowDriver =new frmShowDriverLicenseInfo(LicenseID);
            ShowDriver.ShowDialog();
        }
    }
}
