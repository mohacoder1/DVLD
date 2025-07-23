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

namespace DVLD_Presentation_Layer.Applications.ReplacementLicensesForLostOrDemage
{
    public partial class frmReplaceLicenseForLostOrDemage : Form
    {
        clsLicenses _OldLicense;
        short IssueReason = -1;
        int _NewLicenseID;
        public frmReplaceLicenseForLostOrDemage()
        {
            InitializeComponent();
        }

        private void rbForDemage_CheckedChanged(object sender, EventArgs e)
        {

            if (rbForDemage.Checked)
            {
                lblTitle.Text = "Replacement License Application  For Demage";
                lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RePlaceDrivingLicenseForDemage).FeeS.ToString();

            }
            else
            {
                lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RePlaceDrivingLicenseForLost).FeeS.ToString();
                lblTitle.Text = "Replacement License Application  For Lost";
            }
           
        }

        private void ctrlDriverLicenseInfoWithFilter1_onLicenseSelected(int obj)
        {
            _OldLicense = clsLicenses.Find(obj);
            if (!_OldLicense.IsActive)
            {
                MessageBox.Show("You Cannot Replace This License Because its AlReady Non Active"
                    , "Not Allowed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                tpReplacementApplicationInfo.Enabled = false;
                return;
            }
            if (_OldLicense.isLicenseExpired())
            {
                MessageBox.Show("You Cannot Replace This License Because its AlReady Expired , You need To Renew it!"
                    , "Not Allowed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
               tpReplacementApplicationInfo.Enabled=false;
                return;
            }
            tpReplacementApplicationInfo.Enabled = true;

            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUserID.Text = clsGlobal.CurrentUserInfo.UserName;
            lblOldLicense.Text = _OldLicense.LicenseID.ToString();
        }
       
            
   
        int _SavingApplicationInfo()
        {
            clsApplication Application = new clsApplication();
            Application.personID = _OldLicense.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.LastStatusDate = DateTime.Now;

            if (rbForDemage.Checked)
            {
                Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RePlaceDrivingLicenseForDemage;
                IssueReason = (byte)clsLicenses.enIssueReason.ReplacementForDamaged;
                Application.PayFees = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RePlaceDrivingLicenseForDemage).FeeS;
            }
            else
            {
                Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RePlaceDrivingLicenseForLost;
                Application.PayFees = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RePlaceDrivingLicenseForLost).FeeS;
                IssueReason = (byte)clsLicenses.enIssueReason.ReplacementforLost;
            

            } 

            Application.UserID=clsGlobal.CurrentUserInfo.UserID;
            Application.status = clsApplication.enApplcationStatus.New;

            if (Application.Save())
            return Application.ID;

            return -1;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                private void btnReplaceLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Replacement?","Replacement",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
            {
                if (_SavingApplicationInfo() == -1)
                    return;

                clsLicenses license = _OldLicense.ReplaceLicenseForLostOrDemage(_SavingApplicationInfo(), IssueReason, clsGlobal.CurrentUserInfo.UserID);
                if (license!=null)
                {
                     MessageBox.Show("Your License Replacement Done Successfully! ", "Replacement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnReplaceLicense.Enabled = false;
                _NewLicenseID=license.LicenseID;
                llShowLicense.Visible = true;
                }
                else
                 MessageBox.Show("Your License Replacement Faild! ", "Replacement", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                


            }
        }
        private void frmReplaceLicenseForLostOrDemage_Load(object sender, EventArgs e)
        {
            llShowLicense.Visible = false;
            llShowLicenseHistory.Visible = false;
            tpReplacementApplicationInfo.Enabled = false;
            rbForDemage.Checked = true;    
        }
        private void llShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDriverLicenseInfo frmShow = new frmShowDriverLicenseInfo(_NewLicenseID);
            frmShow.ShowDialog();
        }
    }
}
