using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Applications.DetainAndReleaseLicenses;
using DVLD_Presentation_Layer.Applications.ManageDrivingLicenseApplications.LocalDrivingLicenseApplications;
using DVLD_Presentation_Layer.Applications.ReplacementLicensesForLostOrDemage;
using DVLD_Presentation_Layer.Drivers;
using DVLD_Presentation_Layer.Global;
using DVLD_Presentation_Layer.Licenses.Local_Licenses;
using DVLD_Presentation_Layer.Login;
using DVLD_Presentation_Layer.People.ApplicationTypes;
using DVLD_Presentation_Layer.Test_Types;
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
    public partial class Form1 : Form
    {
        frmLoginScreen _frmLogin;
        public Form1(frmLoginScreen frm)
        {
            InitializeComponent();
            _frmLogin = frm;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool dragging=false;
        Point dragCursor;
        Point dragForm;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging) {
                Point dif = Cursor.Position-new Size(dragCursor);
                this.Location = dif;

            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging=true;
            dragCursor=Cursor.Position;
            dragForm = this.Location;

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;   
        }

        private void localDrivingLiceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDrivingLicense frmAddEdit = new frmAddEditLocalDrivingLicense();

            frmAddEdit.ShowDialog();

        }

        private void internationalDrivingLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicenseAlication frmRenewLicenseAlication = new frmRenewLicenseAlication();
            frmRenewLicenseAlication.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frmReleaseDetainedLicense = new frmReleaseDetainedLicense();
            frmReleaseDetainedLicense.ShowDialog();
        }

        private void replacementForLostOrDemageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLicenseForLostOrDemage forLostOrDemage =new frmReplaceLicenseForLostOrDemage();
            forLostOrDemage.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmLocalApplicationsList frm = new frmLocalApplicationsList();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicaionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalApplicationsList frm =new frmLocalApplicationsList();
            frm.ShowDialog();
        }

        

        private void internationalDrivingLicenseApplicaionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void detainedLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicense frmManageDetainedLicense=new frmManageDetainedLicense();
            frmManageDetainedLicense.ShowDialog();
        }

        private void detainLcenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frmDetainLicenseApplication =new frmDetainLicenseApplication();
            frmDetainLicenseApplication.ShowDialog();
        }

        private void releaseDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frmReleaseDetainedLicense = new frmReleaseDetainedLicense();
            frmReleaseDetainedLicense.ShowDialog();
        }

        private void manageAppilcationsTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApplicationTypesList frmApplicationTypesList = new frmApplicationTypesList();
            frmApplicationTypesList.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestTypesList list = new frmTestTypesList();
            list.ShowDialog();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeopleList frmPeopleList = new frmPeopleList();
            frmPeopleList.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsersList frmUsersList = new frmUsersList();
            frmUsersList.ShowDialog();
        }

        private void drivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriversList frmDriversList = new frmDriversList();
            frmDriversList.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsUser User = clsUser.FindUser(clsGlobal.CurrentUserInfo.UserID);
            frmCurrentUserInfo frmChangePassword = new frmCurrentUserInfo(User.UserID);
            frmChangePassword.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword(clsGlobal.CurrentUserInfo.UserID);
            frmChangePassword.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // clsCurrentUser.UpdateCurrentUser("", "", false);
           // clsGlobal.CurrentUserInfo = null;
           // _frmLogin.Show();
           // this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void detainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
