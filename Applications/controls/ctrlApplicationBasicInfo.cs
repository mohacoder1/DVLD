using DVLD_Business_Layer;
using DVLD_Presentation_Layer.People;
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
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }
        clsApplication _Application;
        public clsApplication SelectedApplication
        {
            set
            {
                _Application = value;
            }
            get
            {
                return _Application;
            }
        }
        int _ApplicationID;
        public int SelectedApplicationID
        {
            set
            {
                _ApplicationID = value;
            }
            get
            {
                return _ApplicationID;
            }
        }
        public void LoadApplicaionInfo(int ID)
        {
            _Application=clsApplication.FindBaseApplication(ID);
            if (_Application!=null)
            {
            lblID.Text=_Application.ID.ToString();
            lblStatus.Text = _Application.StatusText;
            lblStatusDate.Text = _Application.LastStatusDate.ToShortDateString();
            lblDate.Text = _Application.ApplicationDate.ToShortDateString();
            lblType.Text = _Application.ApplicationTypeInfo.Title;
            lblUser.Text = _Application.User.UserName;
            lblPerson.Text = _Application.ApplicanteFullName;
            lblFees.Text=_Application.PayFees.ToString();
            }
            else
            {
                lblID.Text = "[;]";
                lblStatus.Text = "[;]";
                lblStatusDate.Text = "[;]";
                lblDate.Text = "[;]";
                lblType.Text = "[;]";
                lblUser.Text = "[;]";
                lblPerson.Text = "[;]";
                lblFees.Text = "[;]";
            }

        }

        private void ctrlLocalDrivingLicense_Load(object sender, EventArgs e)
        {
        }

        private void llPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfocs frm = new frmShowPersonInfocs(_Application.personID);
            frm.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
