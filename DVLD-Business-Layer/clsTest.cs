using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_Business_Layer
{
    public  class clsTest
    {
        enum enMode
        {
            addNew=0, Update=1,
        }
        enMode _Mode=enMode.addNew;

        public int TestID
        {
            get; set;
        }
        public int TestAppointmentID
        {
            get; set;
        }
        public clsTestAppointments TestAppointmentInfo 
        { 
            get; set;
        }
        public bool TestResult
        {
            get; set;
        }
        public string Notes
        {
            get; set;
        }
        public int CreatedByUserID
        {
            get; set;
        }

        public clsTest()
        {
           
            TestID = -1;
            _Mode= enMode.addNew;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = "";
            CreatedByUserID = -1;
        }
        public clsTest(int testID,int testAppointment,bool testResult,string note , int createdByUserID)
        {
            _Mode= enMode.Update;
            TestID = testID;
            TestAppointmentID = testAppointment;
            TestResult = testResult;
            Notes = note;
            TestAppointmentInfo = clsTestAppointments.Find(TestAppointmentID);
            CreatedByUserID = createdByUserID;
        }
        bool _AddNewTest()
        {
            TestID = clsTestData.AddNewTest(TestAppointmentID, TestResult, Notes, CreatedByUserID);
            return TestID!=-1;
        }
        bool _UpdateTest()
        {
            return clsTestData.UpdateTest( TestID , TestAppointmentID, TestResult, Notes, CreatedByUserID);
          
        }
        public static DataTable GetAllTest()
        {
            return clsTestData.GetAllTests();
        }
        public static clsTest Find(int ID)
        {
            int TestAppointmentID=-1,CreatedByUserID=-1;
            bool TestResult = false;
            string Notes ="";

            return clsTestData.GetTestByTestID(ID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID) ?
                new clsTest(ID, TestAppointmentID, TestResult, Notes, CreatedByUserID) : null;
        }
        public static clsTest FindByAppointmentID(int AppintmentID)
        {
            int TestID = -1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = "";

            return clsTestData.GetTestByTestAppointmentID(ref TestID, AppintmentID, ref TestResult, ref Notes, ref CreatedByUserID) ?
                new clsTest(TestID, AppintmentID, TestResult, Notes, CreatedByUserID) : null;
        }
        public static clsTest GetLastTestByPersonAndLicenseClassAndTestTypeID(int PersonID , int LicenseClassID , int TestTypeID)
        {
            int TestID = -1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = "";
            int AppintmentID = -1;

            return clsTestData.GetLastTestByPersonAndTestTypeAndLicenseClass(PersonID , TestTypeID, LicenseClassID, ref TestID, AppintmentID, ref TestResult, ref Notes, ref CreatedByUserID) ?
                new clsTest(TestID, AppintmentID, TestResult, Notes, CreatedByUserID) : null;
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.addNew:
                    if (_AddNewTest())
                    {
                        _Mode = enMode.Update;
                            return true;
                    }
                    else
                    {
                            return false;

                    }
                case enMode.Update:return _UpdateTest();
                    
                default:return false;
            }
        }
    
        public static int GetPassedTest(int LocalApplicationID)
        {
            return clsTestData.GetPassedTest(LocalApplicationID);
        }
        public static bool isPassedAllTest(int LocalApplicationID)
        {
            return GetPassedTest(LocalApplicationID)==3;
        }

    }
}
