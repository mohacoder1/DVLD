using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Licenses.controls
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        
        clsLicenses _License;
        public clsLicenses SelectedLicenseInfo
        {
            get { return _License; }
        }
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }
        public bool LoadInfoByDriverID(int DriverID)
        {
            _License=clsLicenses.FindByDriverID(DriverID);


            if (LoadLicenseInfo())
                return true;

            else
                return false;

        }
        bool _HandleLicenseExists()
        {
            if (_License!=null)
            {
                return true;
            }
            return false;
            
        }
        public bool LoadInfo(int LicenseID)
        {
            _License = clsLicenses.Find(LicenseID);
           
            if(LoadLicenseInfo())
            return true;

            else 
                return false;

        }
        bool LoadLicenseInfo()
        {
            if (!_HandleLicenseExists())
            {
                MessageBox.Show("There's not Driving License Releated With This Driver ", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
                 return false;
            }
            

            lblClass.Text = _License.LicenseClassInfo.ClassName;
            lblDateOfBirth.Text = _License.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _License.DriverID.ToString();
            lblExDate.Text = _License.ExpirationDate.ToShortDateString();
            lblGender.Text = (_License.DriverInfo.PersonInfo.Gendor == 0) ? "Male" : "Female";

            if (string.IsNullOrEmpty(_License.DriverInfo.PersonInfo.ImagePath))
            {
                pbProfileImage.Image = lblGender.Text == "Male" ? Resources.Male_512 : Resources.Female_512;
            }
            else
                pbProfileImage.ImageLocation = _License.DriverInfo.PersonInfo.ImagePath;

            lblisActive.Text = (_License.IsActive) ? "Yes" : "No";
            lblisDetain.Text = _License.IsLicensesDetained?"Yes":"No";
            lblIssueDate.Text = _License.IssueDate.ToShortDateString();
            lblIssuReason.Text = _License.IssueReasonText;
            lblName.Text = _License.DriverInfo.PersonInfo.fullName;
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblNotes.Text = _License.Notes;
            lblLicenseID.Text = _License.LicenseID.ToString();

            return true;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
