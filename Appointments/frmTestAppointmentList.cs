using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Properties;
using DVLD_Presentation_Layer.Tests;
using DVLD_Presentation_Layer.Tests.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Appointments
{
    public partial class frmTestAppointmentList : Form
    {
        int _LocalDrivngLicenseApplllication = -1;
        clsTestTypes.enTestType _TestType=clsTestTypes.enTestType.Vision;
        DataTable _dtAllAppointment = new DataTable();
        
           
        
        public frmTestAppointmentList(int LocalApplitionID,clsTestTypes.enTestType testType)
        {
            InitializeComponent();
            _LocalDrivngLicenseApplllication=LocalApplitionID;
            _TestType=testType;

        }
        void _refreshData()
        {
            _dtAllAppointment = clsTestAppointments.GetAllTestAppointmentPerTest(_LocalDrivngLicenseApplllication, _TestType);
           // _dtAppointment = _dtAllAppointment.DefaultView.ToTable(false, "TestAppointmentID", "AppointmentDate", "PaidFees", "IsLocked");
            dgvAppointment.DataSource= _dtAllAppointment;
            lblRecordsCount.Text=dgvAppointment.Rows.Count.ToString();  

        }
        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            frmScheduleTest scheduleTest =new frmScheduleTest(_LocalDrivngLicenseApplllication, _TestType);
            scheduleTest.ShowDialog();
        }
        bool _HandleLoadTitleAndImage()
        {
            switch (_TestType)
            {
                case clsTestTypes.enTestType.Vision:
                    pbTestImage.Image = Resources.Vision_512;
                    pbTestImage.SizeMode=PictureBoxSizeMode.Zoom;
                    lblTitle.Text = " Vision Test Appointments ";
                    return true;
                case clsTestTypes.enTestType.Written:
                    pbTestImage.Image = Resources.Written_Test_512;
                    pbTestImage.SizeMode = PictureBoxSizeMode.Zoom;
                    lblTitle.Text = " Written Test Appointments ";
                    return true;
                    
                case clsTestTypes.enTestType.Street:
                    pbTestImage.Image = Resources.driving_test_512;
                    pbTestImage.SizeMode = PictureBoxSizeMode.Zoom;
                    lblTitle.Text = " Street Test Appointments ";
                    return true;
                    
                default:
                    return false;
                    break;
            }
        }

        private void frmTestAppointmentList_Load(object sender, EventArgs e)
        {
            
            if (!_HandleLoadTitleAndImage())
                return;
           
            
             _refreshData();

            ctrlLocalApplicationInfo1.LoadLocalApplicationInfo(_LocalDrivngLicenseApplllication);
            if (dgvAppointment.Rows.Count > 0)
            {
                dgvAppointment.Columns[0].HeaderText = "TAppointment ID";
                dgvAppointment.Columns[0].Width = 160;

                dgvAppointment.Columns[1].HeaderText = "Appointment Date";
                dgvAppointment.Columns[1].Width = 200;

                dgvAppointment.Columns[2].HeaderText = "Paid Fees";
                dgvAppointment.Columns[2].Width = 150;

                dgvAppointment.Columns[3].HeaderText = "is Locked";
                dgvAppointment.Columns[3].Width = 150;


            }
        }

        private void dgvAppointment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmTestAppointmentList_Activated(object sender, EventArgs e)
        {
            _refreshData();
        }

        private void editAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointmentID = (int)dgvAppointment.CurrentRow.Cells[0].Value;

            frmScheduleTest scheduleTest = new frmScheduleTest(_LocalDrivngLicenseApplllication,_TestType,AppointmentID);
            scheduleTest.ShowDialog();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointmentID = (int)dgvAppointment.CurrentRow.Cells[0].Value;
            frmTekeTest frmTeke = new frmTekeTest(AppointmentID);
            frmTeke.ShowDialog();
        }

        private void setLockToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            int AppointmentID = (int)dgvAppointment.CurrentRow.Cells[0].Value;

            clsTestAppointments testAppointments = clsTestAppointments.Find(AppointmentID);
            if (testAppointments.isLocked)
            {
                MessageBox.Show("is Already Locked","message",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                setLockToolStripMenuItem.Enabled = false;
                return;
            }

            testAppointments.isLocked = true;
            if (testAppointments.Save())
            {
            MessageBox.Show("This Appointment Locked Now", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("There's something Wrong ", "message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }
            _refreshData();

        }
    }
}
