using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Appointments;
using DVLD_Presentation_Layer.Licenses;
using DVLD_Presentation_Layer.Licenses.controls;
using DVLD_Presentation_Layer.Tests;
using DVLD_Presentation_Layer.Tests.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Business_Layer.clsTestTypes;

namespace DVLD_Presentation_Layer.Applications.ManageDrivingLicenseApplications.LocalDrivingLicenseApplications
{
    public partial class frmLocalApplicationsList : Form
    {
        static DataTable _dtLocalApps = new DataTable();
        
    
        public frmLocalApplicationsList()
        {
            InitializeComponent();
        }
        void _RefreashData()
        {
            _dtLocalApps= clsLocalLicenseApplications.GetAllLocalLicensesApplications();
            dgvApplication.DataSource = _dtLocalApps;
            lblRecordsCount.Text=dgvApplication.Rows.Count.ToString(); 
        }
        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
           frmAddEditLocalDrivingLicense frmAdd = new frmAddEditLocalDrivingLicense();
            frmAdd.ShowDialog();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDrivingLicense frmAdd = new frmAddEditLocalDrivingLicense((int)dgvApplication.CurrentRow.Cells[0].Value);
            frmAdd.ShowDialog();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalID = (int)dgvApplication.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are You sure you want to Delete this Applications ? ", "Delete Message",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                clsLocalLicenseApplications LocalLicenseApplications =  clsLocalLicenseApplications.FindLocalApplication(LocalID);
                if (LocalLicenseApplications!=null)
                {
                if (LocalLicenseApplications.Delete())
                {
                    MessageBox.Show("this Application  was Deleted Successfully!  ", "Done !",
                    MessageBoxButtons.OK);
                     _RefreashData();
                }
                else
                 MessageBox.Show("This Application was NOT Deleting  ", "ERROR! ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                
                   
                
                }
                else
                 MessageBox.Show("This Application Wasnt Found :-(  ", "Delete Message",MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);


                _RefreashData();
            }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalID = (int)dgvApplication.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are You sure you want to Cancel this Applications ? ", "Cancel Message",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                clsLocalLicenseApplications LocalLicenseApplications = clsLocalLicenseApplications.FindLocalApplication(LocalID);
                if (LocalLicenseApplications != null)
                {
                    if (LocalLicenseApplications.Cancel())
                    {
                        MessageBox.Show("this Application  was Cancelled Successfully!  ", "Done !",
                        MessageBoxButtons.OK);
                        _RefreashData();
                    }
                    else
                        MessageBox.Show("This Application was NOT cancelled  ", "ERROR! ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("This Application Wasnt Found :-(  ", "Cancelled Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                _RefreashData();
            }
        }

        private void frmLocalApplicationsList_Load(object sender, EventArgs e)
        {

            _RefreashData();
            cbFilterBy.SelectedIndex = 0;   
            if (dgvApplication.Rows.Count > 0)
            {
                dgvApplication.Columns[0].HeaderText = "ID";
                dgvApplication.Columns[0].Width = 100;
                dgvApplication.Columns[1].HeaderText = "License Class ";
                dgvApplication.Columns[1].Width = 200;
                dgvApplication.Columns[2].HeaderText = "National No";
                dgvApplication.Columns[2].Width = 100;
                dgvApplication.Columns[3].HeaderText = "Full Name";
                dgvApplication.Columns[3].Width = 250;
                dgvApplication.Columns[4].HeaderText = "Application Date ";
                dgvApplication.Columns[4].Width = 180;
                dgvApplication.Columns[5].HeaderText = "Passed Test Count ";
                dgvApplication.Columns[5].Width = 100; 
                dgvApplication.Columns[6].HeaderText = "Status";
                dgvApplication.Columns[6].Width = 100;
               
            }
        }

        private void showApplicationInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLocalApplicationInfo frm = new frmShowLocalApplicationInfo((int)dgvApplication.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        { 
            string FilterColumn="";
            switch (cbFilterBy.Text)
            {
                case "Local Application ID": FilterColumn = "LocalDrivingLicenseApplicationID";break;
                case "National No": FilterColumn = "NationalNo"; break;
                case "Applicant FullName": FilterColumn = "FullName"; break;
                case "Status": FilterColumn = "Status"; break;
                
            }
            if (cbFilterBy.SelectedIndex==0 || cbFilterBy.Text == "")
            {
                MessageBox.Show("Must Select Any Column To Filtering" , "Filter Problem",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                return;
            }
           
            if (FilterColumn == "LocalDrivingLicenseApplicationID")
            {
            _dtLocalApps.DefaultView.RowFilter= string.Format("[{0}]={1} ", FilterColumn, txtFilter.Text.Trim());
            }
            else
                _dtLocalApps.DefaultView.RowFilter= string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());

                lblRecordsCount.Text = dgvApplication.Rows.Count.ToString();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex==0)
            {
                txtFilter.Visible = false;
                return;
            }
            txtFilter.Visible = true;
            txtFilter.Text = "";
        }

        private void addApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDrivingLicense frmAddEdit = new frmAddEditLocalDrivingLicense();
            frmAddEdit.ShowDialog();
            _RefreashData();
        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {

        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
        bool _checkStatus(int LocalLicenseApplicationID)
        {
            clsLocalLicenseApplications applications = clsLocalLicenseApplications.FindLocalApplication(LocalLicenseApplicationID);
            if (applications.status == clsApplication.enApplcationStatus.Canselled)
            {
                MessageBox.Show("This Application is Already Cancelled!", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int local = (int)(dgvApplication.CurrentRow.Cells[0].Value);
            clsTestTypes.enTestType testType = clsTestTypes.enTestType.Vision;

            if (!_checkStatus(local))
                return;


            if (clsLocalLicenseApplications.DoesPassTestType(local, testType))
            {
                MessageBox.Show("Person already Passed this Test!", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
             frmTestAppointmentList testAppointmentList = new frmTestAppointmentList(local, testType);
            testAppointmentList.ShowDialog();
        }

        private void scheduleTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void writingTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int local = (int)(dgvApplication.CurrentRow.Cells[0].Value);
            clsTestTypes.enTestType testType = clsTestTypes.enTestType.Vision;
            //if (!clsLocalLicenseApplications.DoesPassTestType(local,testType))
            //{
            //   MessageBox.Show("Person should Passed Vision Test first", "Warning",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
            //    return;
            //}
            testType = enTestType.Written;
            //if (clsLocalLicenseApplications.DoesPassTestType(local, testType))
            //{
            //    MessageBox.Show("Person already Passed this Test!", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            //    return;
            //}

            frmTestAppointmentList testAppointmentList = new frmTestAppointmentList(local, testType);
            testAppointmentList.ShowDialog();
           

        }

        private void drivingTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int local = (int)(dgvApplication.CurrentRow.Cells[0].Value);
            clsTestTypes.enTestType testType = clsTestTypes.enTestType.Written;
            //if (!clsLocalLicenseApplications.DoesPassTestType(local, testType))
            //{
            //    MessageBox.Show("Person should Passed written Test first", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            //    return;
            //}
            testType = enTestType.Street;
            //if (clsLocalLicenseApplications.DoesPassTestType(local, testType))
            //{
            //    MessageBox.Show("Person already Passed this Test!", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            //    return;
            //}

            frmTestAppointmentList testAppointmentList = new frmTestAppointmentList(local, testType);
            testAppointmentList.ShowDialog();

            if (clsTest.isPassedAllTest(local))
            {
               clsLocalLicenseApplications applications =  clsLocalLicenseApplications.FindLocalApplication(local);
                applications.SetCompleted();
                issueDrivingLicensefirstTimeToolStripMenuItem.Enabled = true;
            }
        }

        private void frmLocalApplicationsList_Activated(object sender, EventArgs e)
        {
            _RefreashData();
            
        }

        private void issueDrivingLicensefirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int local = (int)(dgvApplication.CurrentRow.Cells[0].Value);
            clsLocalLicenseApplications LocalApplication=clsLocalLicenseApplications.FindLocalApplication(local);
            int PersonID = LocalApplication.personID;
            if (!clsTest.isPassedAllTest(local))
            {
                MessageBox.Show("Person should Pass All test First!", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            if (clsLicenses.GetActiveDriverLicense(LocalApplication.personID, LocalApplication.LicenseClassesID) != -1)
            {
                MessageBox.Show("Person Has Already License realted with this Application!", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            
            frmIssueDrivingLicenseForFirstTime frmIssueDriving =new frmIssueDrivingLicenseForFirstTime(local);
            frmIssueDriving.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int local = (int)(dgvApplication.CurrentRow.Cells[0].Value);
            
            clsLocalLicenseApplications LocalApplication = clsLocalLicenseApplications.FindLocalApplication(local);
            int licenseID = clsLicenses.GetActiveDriverLicense(LocalApplication.personID, LocalApplication.LicenseClassesID);

            if (licenseID==-1)
            {
                MessageBox.Show("Person Does Not Has any License realted with this Application!", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            frmShowDriverLicenseInfo frm = new frmShowDriverLicenseInfo(licenseID);
            frm.ShowDialog();
        }
    }
}
