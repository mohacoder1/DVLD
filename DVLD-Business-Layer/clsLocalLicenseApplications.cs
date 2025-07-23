using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsLocalLicenseApplications:clsApplication
    {
        enum Mode
        {
            AddNew=0, Update=1
        }
        Mode _Mode = Mode.AddNew;

        public int LocalID
        {
            set; get;
        }
        public int LicenseClassesID
        {
            set; get;
        }
        public clsLicenseClasses LicenseClassesInfo
        {
            set; get;
        }
        public clsPeople PersonFullInfo
        {
            set;get;
        }
        public clsLocalLicenseApplications()  
        {
            LocalID = -1;
            LicenseClassesID = -1;
            _Mode = Mode.AddNew; 
        }
        clsLocalLicenseApplications(int LocalId, int AppID, int LicClassID, int ApplicantPersonID, DateTime ApplicationDate,
            int ApplicationTypeID, enApplcationStatus Status, DateTime LastStatusDate, double paidFees, int CreatedbyUserID)
        {
            LocalID = LocalId;
            ID = AppID;
            LicenseClassesID = LicClassID;
            personID = ApplicantPersonID;
            base.ApplicationDate = ApplicationDate;
            base.ApplicationTypeID = ApplicationTypeID;
            base.status = Status;
            base.LastStatusDate = LastStatusDate;
            base.PayFees = paidFees;
            UserID = CreatedbyUserID;
            PersonFullInfo = clsPeople.FindPerson(ApplicantPersonID);
            LicenseClassesInfo = clsLicenseClasses.Find(LicenseClassesID);
            _Mode = Mode.Update;
        }
        public static DataTable GetAllLocalLicensesApplications()
        {
            return clsLocalLicenseApplicationData.GetAll();
        }
        public static clsLocalLicenseApplications FindLocalApplication(int LocalID)
        {
            int AppID = -1, LicenseClsID = -1;

            bool Found = clsLocalLicenseApplicationData.GetLocalApplicationByID(LocalID, ref AppID, ref LicenseClsID);
            if (Found)
            {
                clsApplication application = FindBaseApplication(AppID);

                return new clsLocalLicenseApplications(LocalID, AppID, LicenseClsID, application.personID,
                                application.ApplicationDate, application.ApplicationTypeID, (enApplcationStatus)application.status,
                                application.LastStatusDate, application.PayFees, application.UserID);
            }
            else
            {
                return null;
            }
        }
        public static clsLocalLicenseApplications FindLocalApplicationByApplicationID(int AppID)
        {
            int LocalID = -1, LicenseClsID = -1;
            bool Found = clsLocalLicenseApplicationData.GetLocalApplicationByApplicationID(ref LocalID,  AppID, ref LicenseClsID);
            if (Found)
            {
                clsApplication application = clsApplication.FindBaseApplication(AppID);
                return new clsLocalLicenseApplications(LocalID, application.ID, LicenseClsID, application.personID,
                                application.ApplicationDate, application.ApplicationTypeID, (enApplcationStatus)application.status,
                                application.LastStatusDate, application.PayFees, application.UserID);
            }
            else
            {
                return null;
            }
        }
        bool _AddNew()
        {
            LocalID = clsLocalLicenseApplicationData.AddNewApplications(base.ID, LicenseClassesID);
            return LocalID != -1;
        }
        bool _UpdateApplication()
        {
            return clsLocalLicenseApplicationData.UpdateApplicationinfo(LocalID,ID, LicenseClassesID);
             
        }
        public bool SaveApplication()

        {
            base._mode = (clsApplication. enMode)_Mode;
            if (!base.Save())
            {
                return false;
            }
           
            switch (_Mode)
            {
                case Mode.AddNew:
                    if (_AddNew())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    case Mode.Update: return _UpdateApplication();
                    
                default:return false;
                   
            }
        }
        public bool DoesPassTestType(clsTestTypes.enTestType testType)
        {
            return clsLocalLicenseApplicationData.DoesPassTestType(LocalID, (int)testType)!=-1;
        }
        public static bool DoesPassTestType(int ID,clsTestTypes.enTestType testType)
        {
            return clsLocalLicenseApplicationData.DoesPassTestType(ID, (int)testType) != -1;
        }
        public bool DoesAttendTestType(clsTestTypes.enTestType testType)
        {
            return clsLocalLicenseApplicationData.DoesAttendTestType(LocalID, (int)testType);
        }
        public  int TotalTrialPerTest(clsTestTypes.enTestType testType)
        {
            return clsLocalLicenseApplicationData.TotalTrialPerTest(LocalID, (int)testType);
        }
        public bool isThereAnActiveScheduledTest(clsTestTypes.enTestType testType)
        {
            return clsLocalLicenseApplicationData.isThereAnActiveScheduledTest(LocalID, (int)testType);
        }
        public static  bool isThereAnAppilcationExistsWithThisLicenseClassID(int PersonID , int LicenseClassID)
        {
            return clsLocalLicenseApplicationData.isThereAnAppilcationExistsWithThisLicenseClassID(PersonID, LicenseClassID);
        }


    }
}
