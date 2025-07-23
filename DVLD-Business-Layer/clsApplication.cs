using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Deployment.Internal;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsApplication
    {
        
        public enum enMode
        {
            addNew=0,Update=1
        }
        public  enMode _mode = enMode.addNew;
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, 
            RePlaceDrivingLicenseForDemage = 4, RePlaceDrivingLicenseForLost = 3,
            ReleaseDetainedLicenses = 5, NewInternationalDrivingLicense = 6,RetakeTest=14
        }
        public enApplicationType applicationType
       {
            get; set;
       }
        public enum enApplcationStatus
        {
            New=1,Canselled=2, Completed=3
        }
        public enApplcationStatus status
        {
            set;get;
        }   
        public int ID
        {
            get; set;
        }
        public int personID
        {
            get; set;
        }
        public string ApplicanteFullName
        {
            get
            {
                return Person.fullName;
            }
        }
        public int UserID
        {
            get; set;
        }
        public int ApplicationTypeID
        {
            get; set;
        }
        public DateTime ApplicationDate
        {
            get; set;
        }
        public DateTime LastStatusDate
        {
            get; set;
        }
        public double PayFees
        {
            get; set;
        }
        public clsPeople Person
        {
            get; set;
        }
        public clsUser User
        {
            get; set;
        }
        public clsApplicationTypes ApplicationTypeInfo
        {
            get; set;
        }
        public string StatusText
        {
            get
            {
                switch (status)
                {
                    case enApplcationStatus.New:return "New";
                        
                    case enApplcationStatus.Canselled: return "Cancelled";

                    case enApplcationStatus.Completed: return "Completed";

                    default:
                        break;
                }
                return "Unknown";
            }
        }
        public clsApplication() 
        {
            _mode = enMode.addNew;
            ID = -1;
            personID = -1;
            ApplicationTypeID = -1;
            UserID = -1;
            ApplicationDate = DateTime.Now;
            LastStatusDate = DateTime.Now;
            PayFees = -1;
            status = enApplcationStatus.New;

            Person = null;
            User = null;
            ApplicationTypeInfo = null;
        }
        clsApplication(int AppID,int ApplicantPersonID,DateTime ApplicationDate ,
            int ApplicationTypeID, enApplcationStatus Status, DateTime LastStatusDate,double paidFees, int CreatedbyUserID)
             
        {
            _mode= enMode.Update;
            ID = AppID;
            personID = ApplicantPersonID;
            this.ApplicationTypeID = ApplicationTypeID;
            UserID = CreatedbyUserID;
            this.ApplicationDate = ApplicationDate;
            this.LastStatusDate = LastStatusDate;
            PayFees = paidFees;
            status = Status;
            Person = clsPeople.FindPerson(personID);
            User = clsUser.FindUser(UserID);
            ApplicationTypeInfo = clsApplicationTypes.Find(ApplicationTypeID);
        }
        public static clsApplication FindBaseApplication(int ID)
        {
            
            int personID = -1,
            ApplicationTypeID = -1,
            UserID = -1;
            DateTime ApplicationDate = DateTime.Now,
            LastStatusDate = DateTime.Now;
            double PayFees = -1;
            short ApplicationStatus = -1;
            return clsApplicationData.GetApplicationByID(ID, ref personID, ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus,
                ref LastStatusDate, ref PayFees, ref UserID) ? new clsApplication(ID, personID, ApplicationDate, ApplicationTypeID, (enApplcationStatus)ApplicationStatus,
                 LastStatusDate, PayFees, UserID) : null;
        }
        public static DataTable GetAllApplications()
        {
            return clsLocalLicenseApplicationData.GetAll();
        }
        public static bool isApplicationExists(int ID)
        {
            return clsApplicationData.isAppExists(ID);  
        }
        bool _AddNewApplication()
        {
            this.ID = clsApplicationData.AddNewApplication(personID, ApplicationDate, ApplicationTypeID,
                (short)status, LastStatusDate, PayFees, UserID);

            return this.ID != -1;
        }
        bool _UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(ID,personID, ApplicationDate, ApplicationTypeID,
                (short)status, LastStatusDate, PayFees, UserID);
        }
        public bool Save()
        {
            switch (_mode)
            {
                case enMode.addNew:
                    if (_AddNewApplication())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:return _UpdateApplication();
                    
                default:
                    break;
            }
            return false;
        }
        public static  bool Cancel(int ID)
        {
            return clsApplicationData.UpdateStatus(ID, 2);
        }

        public bool Cancel()
        {
            return clsApplicationData.UpdateStatus(ID, 2);
        }
        public  bool SetCompleted()
        {
            return clsApplicationData.UpdateStatus(ID, 3);
        }
        public  bool Delete()
        {
            return clsApplicationData.DeleteApplication(ID);
        }
        public  static bool Delete(int ID )
        {
            return clsApplicationData.DeleteApplication(ID);
        }

        public static bool DoesPersonHasActiveApplication(int PersonID , int ApplicationTypeID)
        {
            return clsApplicationData.DoesPersonHasActiveApplication(PersonID , ApplicationTypeID);
        }
        public bool DoesPersonHasActiveApplication(int ApplicationTypeID)
        {
            return clsApplicationData.DoesPersonHasActiveApplication(personID , ApplicationTypeID);
        }

        public static int GetActiveApplicationID(int personID,enApplicationType ApplicationType)
        {
            return clsApplicationData.GetActiveAppID(personID, (short)ApplicationType);
        }
        public int GetActiveApplicationID(enApplicationType ApplicationType)
        {
            return clsApplicationData.GetActiveAppID(personID, (short)ApplicationType);
        }
        public static int GetActiveApplicationIDForLicenseClasses(int personID, enApplicationType ApplicationType, int LicenseClassID)
        {
            return clsApplicationData.GetActiveAppIDForLicenses(personID, (short)ApplicationType, LicenseClassID);
        }
        public int GetActiveApplicationIDForLicenseClasses(enApplicationType ApplicationType , int LicenseClassID)
        {
            return clsApplicationData.GetActiveAppIDForLicenses(personID, (short)ApplicationType, LicenseClassID);

        }

    }
}
