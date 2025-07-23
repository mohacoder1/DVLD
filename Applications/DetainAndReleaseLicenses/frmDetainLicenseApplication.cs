using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Global;
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

namespace DVLD_Presentation_Layer.Applications.DetainAndReleaseLicenses
{
    public partial class frmDetainLicenseApplication : Form
    {
        clsLicenses _License;
        int _LicenseID = -1;
        public frmDetainLicenseApplication()
        {
            InitializeComponent();
        }
        public frmDetainLicenseApplication( int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        private void frmDetainLicenseApplication_Load(object sender, EventArgs e)
        {
            if (_LicenseID==-1)
            {
            gbDetain.Enabled = false;
            btnDetain.Enabled = false;
                return;
            }
            ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(_LicenseID);
            ctrlDriverLicenseInfoWithFilter1.Enabled = false;

            
        }
        void _LoadData()
        {
            gbDetain.Enabled = true;
            btnDetain.Enabled = true;
            lblCreatedByUserID.Text = clsGlobal.CurrentUserInfo.UserName;
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblLicenseID.Text = _LicenseID.ToString();
        }
        private void ctrlDriverLicenseInfoWithFilter1_onLicenseSelected(int obj)
        {
            _License=clsLicenses.Find(obj);

            if (_License.IsLicensesDetained)
            {
                MessageBox.Show("Your License is Already Detained!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                gbDetain.Enabled = false;  
                return;
            }
            _LoadData();
          

        }
        private void btnDetain_Click(object sender, EventArgs e)
        {
            int UserID = clsGlobal.CurrentUserInfo.UserID;
            double Fees = Convert.ToDouble(txtFees.Text);
            int ID = _License.Detain(UserID, Fees);
            if (ID != -1)
            {

                MessageBox.Show("Your License was Detained successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDetain.Enabled = false;
                lblDetainID.Text = ID.ToString();
            }
            else
                MessageBox.Show("Your License wasnt Detained !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
