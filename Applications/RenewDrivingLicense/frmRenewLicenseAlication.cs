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

namespace DVLD_Presentation_Layer.Licenses.Local_Licenses
{
    public partial class frmRenewLicenseAlication : Form
    {
        public frmRenewLicenseAlication()
        {
            InitializeComponent();
        }
        clsLicenses _License;
        int _LicenseID;
        private void ctrlDriverLicenseInfoWithFilter1_onLicenseSelected(int obj)
        {
            _License = clsLicenses.Find(obj);
            if (!_License.isLicenseExpired())
            {
                MessageBox.Show($"You Cannot Renew This License because its Not Expired yet ,it Expire in {_License.ExpirationDate}", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
                tpRenewApplicationInfo.Enabled = false;
                return;
            }
            if (!_License.IsActive)
            {
                MessageBox.Show($"You Cannot Renew This License because its Not Active ", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
                tpRenewApplicationInfo.Enabled = false;
                return;
            }
            tpRenewApplicationInfo.Enabled = true;
            _LoadInfo();
        }
        int _SavingApplication()
        {
            clsApplication application  = new clsApplication();
            application.personID = _License.DriverInfo.PersonID;
            application.UserID=clsGlobal.CurrentUserInfo.UserID;
            application.ApplicationDate=DateTime.Now;
            application.status = clsApplication.enApplcationStatus.New;
            application.PayFees = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).FeeS;
            application.ApplicationTypeID = 2;
            application.LastStatusDate = DateTime.Now;
            if (application.Save())
            {
                application.SetCompleted();
                return application.ID;
            }
            return -1;
        }
        void _LoadInfo()
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).FeeS.ToString();
            lblCreatedByUserID.Text = clsGlobal.CurrentUserInfo.UserName;
            lblExpirationDate.Text = DateTime.Now.AddYears(_License.LicenseClassInfo.DefaultValidityLength).ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblLicenseFees.Text=_License.LicenseClassInfo.ClassFees.ToString();
            lblOldLicense.Text=_License.LicenseID.ToString();
            lblTotalFees.Text=(Convert.ToDouble(lblApplicationFees.Text)+ Convert.ToDouble(lblLicenseFees.Text)).ToString();  
        }
        private void frmRenewLicenseAlication_Load(object sender, EventArgs e)
        {
            tpRenewApplicationInfo.Enabled = false;
            llShowLicense.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            clsLicenses NewLicense= new clsLicenses();
            NewLicense.ApplicationID = _SavingApplication();
            NewLicense.Notes=txtNotes.Text;
            NewLicense.DriverID=_License.DriverID;
            NewLicense.CreatedByUserID = clsGlobal.CurrentUserInfo.UserID;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(_License.LicenseClassInfo.DefaultValidityLength);
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.PaidFees=_License.PaidFees;
            NewLicense.IsActive= true;
            NewLicense.IssueReason = clsLicenses.enIssueReason.Renew;
            NewLicense.LicenseClassID = _License.LicenseClassID;
            if (NewLicense.Save()&&_License.DeactiveLicense())
            {
                _LicenseID = NewLicense.LicenseID;
                llShowLicense.Visible = true;
                lblRenewLicenseID.Text = NewLicense.LicenseID.ToString();
                lblRenewApplicationID.Text = NewLicense.ApplicationID.ToString();
                btnRenewLicense.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.FilterEnable = false;
                MessageBox.Show($"License Renewed Successfully ,Yor new License ID = {NewLicense.LicenseID} ", "Renew License", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"There's Something wrong ,License Didnt Renew Successfully" , "Renew License", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);

            }

        }

        private void llShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDriverLicenseInfo frmShowDriverLicenseInfo=new frmShowDriverLicenseInfo(_LicenseID);
            frmShowDriverLicenseInfo.ShowDialog();
        }
    }
}
