using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_Business_Layer
{
    public class clsTestAppointments
    {



        enum enMode
        {
            AddNew=0, Update=1
        }
        enMode mode = enMode.AddNew;
        public int TestAppointmentID
        {
            get; set;
        }
        public clsTestTypes.enTestType TestTypeID
        {
            get; set;
        }
        public int CreatedByUserID
        {
            get; set;
        }
        public int TestID
        {
            get; set;
        }
    
        public int LocalDrivingLicenseApplicationID
        {
            get; set;
        }
        public DateTime AppointmentDate
        {
            get; set;
        }
        public double PaidFees
        {
            get; set;
        }
        public bool isLocked
        {
            get; set;
        }
        public int RetakeTestApplicationID
        {
            get; set;
        }

        public clsTestTypes testTypeInfo
        {
            get; set;
        }
        public clsApplication RetakeApplicationsInfo
        {
            get; set;
        }

        public clsTestAppointments()
        {
            
            TestAppointmentID = -1;
            this.TestTypeID = clsTestTypes.enTestType.Vision;
            this.CreatedByUserID = -1;
            this.isLocked = false;
            this.RetakeTestApplicationID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = -1;
            this.RetakeApplicationsInfo = null;
            this.testTypeInfo = null;
            mode = enMode.AddNew;
        }
      //  [TestAppointmentID]
      //,[TestTypeID]
      //,[LocalDrivingLicenseApplicationID]
      //,[AppointmentDate]
      //,[PaidFees]
      //,[CreatedByUserID]
      //,[IsLocked]
      //,[RetakeTestApplicationID]
        public clsTestAppointments(int testAppointmentID,clsTestTypes.enTestType testTypeID, int localDrivingLicenseApplicationID, 
            DateTime appointmentDate , double paidFees,int createdByUserID, bool IsLocked, int REtakeTestApplicationID)
        {

            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            CreatedByUserID = createdByUserID;
            this.isLocked = isLocked;
            this.RetakeTestApplicationID = REtakeTestApplicationID;
            this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.AppointmentDate = appointmentDate;
            this.PaidFees = paidFees;
            this.RetakeApplicationsInfo = clsApplication.FindBaseApplication(REtakeTestApplicationID);
            
            mode = enMode.Update;
        }
        bool _AddNewAppointement()
        {
            TestAppointmentID = clsTestApointmentsData.AddNewTestApointment((int)TestTypeID, LocalDrivingLicenseApplicationID,
                AppointmentDate, PaidFees, CreatedByUserID, isLocked, RetakeTestApplicationID);
            return TestAppointmentID != -1;
        }
        bool _UpdateAppointement()
        {
            return clsTestApointmentsData.UpdateTestApointment(TestAppointmentID, (int)TestTypeID, LocalDrivingLicenseApplicationID,
                AppointmentDate, PaidFees, CreatedByUserID, isLocked, RetakeTestApplicationID);
        }

        public bool Save()
        {
            switch (mode)
            {
                case enMode.AddNew:
                    if (_AddNewAppointement())
                    {
                        mode = enMode.Update;
                        return true;

                    }
                    else
                    {
                        return false;

                    }

                case enMode.Update:return _UpdateAppointement();
                  
                default:return false;
                   
            }
          
        }

        public static DataTable GetAllTestAppointment()
        {
            return clsTestApointmentsData.GetAllTestApointment();
        }
        public static  DataTable GetAllTestAppointmentPerTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            return clsTestApointmentsData.GetApplicationTestApointmentPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static clsTestAppointments Find(int TestAppointmentID)
        {
            int TestTypeID=-1, LocalDrivingLicenseApplicationID=-1, CreatedByUserID=-1, RetakeTestApplicationID=-1;
            DateTime AppointmentDate= DateTime.Now;
            bool isLocked=false;
            double PaidFees = -1;
            return clsTestApointmentsData.GetTestApointmentByID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID
                , ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref isLocked, ref RetakeTestApplicationID) ? new clsTestAppointments(TestAppointmentID, (clsTestTypes.enTestType) TestTypeID, LocalDrivingLicenseApplicationID
                ,  AppointmentDate,  PaidFees, CreatedByUserID, isLocked, RetakeTestApplicationID) : null;
        }
        public static clsTestAppointments FindLastTestAppointment(int localDrivingLicenseApplicationID, int TestTypeID)
        {
            int TestAppointmentID = -1, CreatedByUserID=-1, RetakeTestApplicationID=-1;
            DateTime AppointmentDate= DateTime.Now;
            bool isLocked=false;
            double PaidFees = -1;

            return clsTestApointmentsData.GetLastTestApointment(ref TestAppointmentID, TestTypeID,  localDrivingLicenseApplicationID
                , ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref isLocked, ref RetakeTestApplicationID) ? new clsTestAppointments(TestAppointmentID, (clsTestTypes.enTestType)TestTypeID, localDrivingLicenseApplicationID
                ,  AppointmentDate,  PaidFees, CreatedByUserID, isLocked, RetakeTestApplicationID) : null;
        }
        static public bool isTestAppintmentLocked(int TestAppointmentID)
        {
            return clsTestApointmentsData.isTestAppintmentLocked(TestAppointmentID);
        }
        public bool isTestAppintmentLocked()

        {
            return clsTestApointmentsData.isTestAppintmentLocked(TestAppointmentID);
        }
        int _GetTestID()
        {
            return  clsTestApointmentsData.GetTestID(TestAppointmentID);
           
        }


    }
}
