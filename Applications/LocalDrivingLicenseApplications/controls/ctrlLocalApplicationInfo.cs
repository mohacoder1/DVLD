using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Applications.ManageDrivingLicenseApplications.LocalDrivingLicenseApplications.controls
{
    public partial class ctrlLocalApplicationInfo : UserControl
    {

        public ctrlLocalApplicationInfo()
        {
            InitializeComponent();
        }
        clsLocalLicenseApplications _localLicenseApplication;
        int _LocalAppID=-1;
        public int SelectedLocalAppID
        {
            set
            {
                _LocalAppID = value;
            }
            get
            {
                return _LocalAppID;
            }
        }
        public clsLocalLicenseApplications SelectedlocalLicenseApplication
        {
            set
            {
                _localLicenseApplication = value;
            }
            get
            {
                return _localLicenseApplication;
            }
        }
        private void lblID_Click(object sender, EventArgs e)
        {

        }
        public void LoadLocalApplicationInfo(int localAppID)
        {
             _localLicenseApplication =  clsLocalLicenseApplications.FindLocalApplication(localAppID);
              lblID.Text= localAppID.ToString();
              lblApplicationType.Text = clsLicenseClasses.Find(_localLicenseApplication.LicenseClassesID).ClassName;
              lblPassedTest.Text = "[?/3]";
              ctrlApplicationBasicInfo1.LoadApplicaionInfo(_localLicenseApplication.ID);
        }
    }
}
