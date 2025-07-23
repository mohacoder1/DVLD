using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Licenses
{
    public partial class frmIssueDrivingLicenseForFirstTime : Form
    {
        int _LocalID = -1;
       int _DriverID = -1;
       int _LicenseID = -1;
        clsLocalLicenseApplications _localLicenseApplication;
        clsLicenses _License;
        public frmIssueDrivingLicenseForFirstTime(int LocalID)
        {
            InitializeComponent();
            _LocalID = LocalID;
        }

        private void frmIssueDrivingLicenseForFirstTime_Load(object sender, EventArgs e)
        {
            ctrlLocalApplicationInfo1.LoadLocalApplicationInfo(_LocalID);
            _localLicenseApplication = clsLocalLicenseApplications.FindLocalApplication(_LocalID);

        }
        bool _HandleDriverProcess()
        {
            clsDrivers driver=new clsDrivers();
            driver.CreatedDate = DateTime.Now;
            driver.CreatedByUserID= clsGlobal.CurrentUserInfo.UserID;
            driver.PersonID= _localLicenseApplication.personID;
            if (driver.Save())
            {
                _DriverID = driver.DriverID;
                return true;
            }
            return false;
        }
        bool _HandleLicenseSavingProcess()
        {
            _License = new clsLicenses();
            _License.ApplicationID = _localLicenseApplication.ID;
            _License.IssueDate = DateTime.Now;
            _License.Notes = txtNote.Text;
            _License.CreatedByUserID = clsGlobal.CurrentUserInfo.UserID;
            _License.IsActive = true;
            _License.IssueReason = clsLicenses.enIssueReason.FirstTime;
            _License.ExpirationDate = DateTime.Now.AddYears(_localLicenseApplication.LicenseClassesInfo.DefaultValidityLength);
            _License.LicenseClassID = _localLicenseApplication.LicenseClassesID;
            _License.PaidFees = clsApplicationTypes.Find((int)clsApplication.enApplicationType.NewDrivingLicense).FeeS;
            _License.DriverID = _DriverID;
              
            if (_License.Save())
            {
                _LicenseID= _License.LicenseID;
                return true;
            }
                
            else
                return false;
        }
        private void btnIssue_Click(object sender, EventArgs e)
        {
            

               if (!_HandleDriverProcess())
                    return;
            

            if (_HandleLicenseSavingProcess())
                MessageBox.Show($"Issue License Done Successfully your LicenseID= {_LicenseID}","Done !",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
            else
                 MessageBox.Show("Issue License Doesnt Done Successfully ", "Error",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
            

        }
    }
}
