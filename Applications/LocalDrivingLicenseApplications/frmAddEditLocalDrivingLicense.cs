using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Global;
using DVLD_Presentation_Layer.People.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Applications.ManageDrivingLicenseApplications.LocalDrivingLicenseApplications
{
    public partial class frmAddEditLocalDrivingLicense : Form
    {
        clsLocalLicenseApplications localLicenseApplications=null;

        int _LocalApplicationID = -1,_personID=-1;
        
        enum enMode
        {
            AddNew=0,Update=1
        }
        enMode mode= enMode.AddNew; 
        public frmAddEditLocalDrivingLicense()
        {
            InitializeComponent();
            mode = enMode.AddNew;

        }
        public frmAddEditLocalDrivingLicense(int LocalApplicationID)
        {
            InitializeComponent();
            _LocalApplicationID = LocalApplicationID; 
            mode = enMode.Update;
        }
        void _FillLicenseClasses()
        {
           DataTable dt = clsLicenseClasses.GetLicensesClassesNames();
            foreach (DataRow item in dt.Rows)
            {
                cbLicenseClasses.Items.Add(item["ClassName"]);
            }
            cbLicenseClasses.SelectedIndex = 0;
        }
        void _LoadApplicationInfo()
        {
            localLicenseApplications = clsLocalLicenseApplications.FindLocalApplication(_LocalApplicationID);
            if (cbLicenseClasses.Items.Count<=0)
            {
                _FillLicenseClasses();
            }
            if (localLicenseApplications == null )
            {
                MessageBox.Show("No Application is exists ","Not Found",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                return;
            }

            lblID.Text = localLicenseApplications.LocalID.ToString();
            lblFees.Text=localLicenseApplications.PayFees.ToString();
            lblcreatedUser.Text = clsUser.FindUser( localLicenseApplications.UserID).UserName;
            lblDate.Text=localLicenseApplications.ApplicationDate.ToShortDateString();
            ctrlPersonInfoWithFilter1.LoadPersonInfo(localLicenseApplications.personID);
            ctrlPersonInfoWithFilter1.FilterEnable=false;
            ctrlPersonInfoWithFilter1.value = localLicenseApplications.personID.ToString();
            cbLicenseClasses.SelectedIndex=cbLicenseClasses.FindString(clsLicenseClasses.Find(localLicenseApplications.LicenseClassesID).ClassName);
            btnNext.Enabled=true;
        }
        void _ResetLabels()
        {
            if (mode==enMode.AddNew)
            {
                localLicenseApplications = new clsLocalLicenseApplications();
            lblID.Text = "{???}";
            lblFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.NewDrivingLicense).FeeS.ToString();
            lblDate.Text=DateTime.Now.ToShortDateString();
            lblcreatedUser.Text=clsGlobal.CurrentUserInfo.UserName;
            _FillLicenseClasses();
            btnNext.Enabled=false; 
            btnSave.Enabled = false;   
            }
            else
            {
                tbApplication.Enabled = true;
                btnSave.Enabled = true;
            }


        }
       

        private void frmAddEditLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            _ResetLabels();
            if (mode==enMode.Update)
            {
                _LoadApplicationInfo();
               
            }
            

        }
        bool _savingInfo()
        {
            if (clsLocalLicenseApplications.isThereAnAppilcationExistsWithThisLicenseClassID(_personID, cbLicenseClasses.SelectedIndex + 1))
            {
                MessageBox.Show("There's Already an Active Application Releated With this Person ID", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return false;
            }

            localLicenseApplications.LicenseClassesID = cbLicenseClasses.SelectedIndex + 1;
            localLicenseApplications.PayFees=Convert.ToDouble(lblFees.Text);
            localLicenseApplications.status= clsApplication.enApplcationStatus.New;
            localLicenseApplications.personID = _personID;
            localLicenseApplications.ApplicationDate = DateTime.Now;
            localLicenseApplications.applicationType = clsApplication.enApplicationType.NewDrivingLicense;
            localLicenseApplications.ApplicationTypeID = 1;
            localLicenseApplications.LastStatusDate = DateTime.Now; 
            localLicenseApplications.UserID=clsGlobal.CurrentUserInfo.UserID; 
            localLicenseApplications.LicenseClassesID = cbLicenseClasses.SelectedIndex + 1;
            localLicenseApplications.personID = ctrlPersonInfoWithFilter1.SelectedPersonID;

                if (localLicenseApplications.SaveApplication())
                {
                    lblID.Text = localLicenseApplications.LocalID.ToString();
                    mode = enMode.Update;
                    return true;
                }
            return false;   
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (_savingInfo())
            {
                MessageBox.Show("This Data Has Saved Successfully! ", "Done!", MessageBoxButtons.OK,MessageBoxIcon.Information);
                
            }
           else 
            MessageBox.Show("This Data Has Not Saved Successfully! ", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);


        }

        private void frmAddEditLocalDrivingLicense_Activated(object sender, EventArgs e)
        {
            ctrlPersonInfoWithFilter1.FilterFocus();
        }

        private void tpPerson_Click(object sender, EventArgs e)
        {

        }

        private void ctrlPersonInfoWithFilter1_onPersonSelected(int obj)
        {
           
            _personID = obj;
            if (_personID!=-1)
            {
                btnNext.Enabled = true;
                btnSave.Enabled = true;
            }
        }
    }
}
