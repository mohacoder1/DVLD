using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Applications.ManageDrivingLicenseApplications.LocalDrivingLicenseApplications;
using DVLD_Presentation_Layer.People;
using DVLD_Presentation_Layer.People.ApplicationTypes;
using DVLD_Presentation_Layer.Tests.controls;
using DVLD_Presentation_Layer.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer
{
    public partial class frmTest : Form
    {
      
        public frmTest()
        {
            InitializeComponent();
        }
       
        private void frmTest_Load(object sender, EventArgs e)
        {
           // userControl11.FilterEnable = false;
           AcceptButton=userControl11.acceptedButton;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(15);
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmLocalApplicationsList frm= new frmLocalApplicationsList();  
            frm.ShowDialog();
        }
         void _FillInformation()
        {
            //ctrlLocalDrivingLicense1.LoadApplicaionInfo();
          //  ctrlLocalApplicationInfo1.LoadLocalApplicationInfo();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //frmA frm= new frmPeopleList();
            //frm.ShowDialog();
        }

        private void txtCountry_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //frmTekeTest
        }

        private void btnSearch_Click(object sender, EventArgs e){
        
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            userControl11.LoadLicenseInfo(int.Parse(txtAppID.Text));
        }

        void _FindNow(int ID)
        {
        }
        void _FindNow(string ID)
        {
        }

        private void ctrlPersonInfoWithFilter1_onPersonSelected(int obj)
        {
            txtID.Text = obj.ToString();    
        }

        private void ctrlScheduledTest1_Load(object sender, EventArgs e)
        {

        }

        private void txtAppID_TextChanged(object sender, EventArgs e)
        {

        }

        private void userControl11_onLicenseSelected(int obj)
        {
            txtUsername.Text = obj.ToString();
        }
    }
}
