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

namespace DVLD_Presentation_Layer.Applications.DetainAndReleaseLicenses
{
    public partial class frmReleaseDetainedLicense : Form
    {
        clsLicenses _license;
        clsDetainedLicenses DetainedLicenses;
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        private void ctrlDriverLicenseInfoWithFilter1_onLicenseSelected(int obj)
        {
            _license = clsLicenses.Find(obj);
            DetainedLicenses=clsDetainedLicenses.FindByLicenseID(obj);
            if (!_license.IsLicensesDetained)
            {

                MessageBox.Show("Your License Doesn't Detained!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRelease.Enabled = false;
                gbRelease.Enabled = false;
                return;
            }
            btnRelease.Enabled = true;
            gbRelease.Enabled = true;
            lblFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.ReleaseDetainedLicenses).FeeS.ToString();
            lblLicenseID.Text=obj.ToString();
            lblReleaseDate.Text = DateTime.Now.ToShortDateString();
            lblReleasedByUserID.Text=clsGlobal.CurrentUserInfo.UserName;
            lblDetainDate.Text = DetainedLicenses.DetainDate.ToShortDateString();
            
        }
        int _createApplication()
        {
            clsApplication application = new clsApplication();
            application.ApplicationDate = DateTime.Now;
            application.LastStatusDate = DateTime.Now;
            application.PayFees = clsApplicationTypes.Find((int)clsApplication.enApplicationType.ReleaseDetainedLicenses).FeeS;
            application.personID=_license.DriverInfo.PersonID;
            application.status = clsApplication.enApplcationStatus.New;
            application.UserID= clsGlobal.CurrentUserInfo.UserID;
            application.ApplicationTypeID = 5;

            return application.Save() ? application.ID : -1;



        }
        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            gbRelease.Enabled = false;
            btnRelease.Enabled = false;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            int AppID = _createApplication();
            if (AppID==-1)
                
            {
                MessageBox.Show("Your License was not Released!", "error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                btnRelease.Enabled = false;
                return;
            }
            DetainedLicenses.ReleaseApplicationID = AppID;
            DetainedLicenses.ReleasedByUserID= clsGlobal.CurrentUserInfo.UserID ;
            DetainedLicenses.ReleaseDate = DateTime.Now;
            if (DetainedLicenses.ReleaseDetainedLicense())
            {
                DetainedLicenses.IsReleased = true;
                lblReleaseApplicationID.Text = AppID.ToString();
                MessageBox.Show("Your License is Released Now!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRelease.Enabled = false;
                gbRelease.Enabled = false;
            }
            else
            {
                MessageBox.Show("ll!", "Dokkne", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);

            }




        }
    }
}
