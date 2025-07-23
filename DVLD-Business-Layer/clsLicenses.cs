using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Business_Layer.clsLicenses;

namespace DVLD_Business_Layer
{
    public  class clsLicenses
    {
        
        enum enMode
        {
            addnew=0,Update=1
        }
        enMode _Mode = enMode.addnew;
       public enum enIssueReason
        {
            FirstTime=1, Renew=2,ReplacementforLost=3, ReplacementForDamaged=4
        }
        public string Notes
        {
            set; get;
        }
        public clsDrivers DriverInfo
        {
            set; get;
        }
        public clsDetainedLicenses DetainedLicensesInfo
        {
            set; get;
        }

        public clsLicenseClasses LicenseClassInfo
        {
            set; get;
        }
        public enIssueReason IssueReason
        {
            set; get;
        }
        public bool IsActive
        {
            set; get;
        }
        public bool IsLicensesDetained
        {
            set;get;
        }

        public int ApplicationID
        {
            set; get;
        }
        public int CreatedByUserID
        {
            set; get;
        }
        public int DriverID
        {
            set; get;
        }
        public DateTime IssueDate
        {
            set; get;
        }
        public DateTime ExpirationDate
        {
            set; get;
        }
        public double PaidFees
        {
            set; get;
        }
        public int LicenseClassID
        {
            set; get;
        }
        public int LicenseID
        {
            set; get;
        }
        public string IssueReasonText
        {
            get
            {
                switch (IssueReason)
                {
                    case enIssueReason.FirstTime:return "Issue License For First Time";
                    case enIssueReason.Renew: return "Renew License";
                    case enIssueReason.ReplacementForDamaged: return "Replacement License For Demaged ";
                    case enIssueReason.ReplacementforLost: return "Replacement License For Lost ";
                    default:return "Uknown";
                       
                }
            }
        }
        private clsLicenses(int ID, int applicationID, int driverID, int licenseClassID, DateTime issueDate,
            DateTime expirationDate, string notes, double paidFees, bool isActive, enIssueReason issueReason, int createdByUserID)
        {
            LicenseClassInfo = clsLicenseClasses.Find(licenseClassID);
            DriverInfo=clsDrivers.Find(driverID);
            DetainedLicensesInfo = clsDetainedLicenses.FindByLicenseID(ID);
            IsLicensesDetained = clsDetainedLicenses.isDetainedLicenses(ID);
            _Mode = enMode.Update;
            LicenseID = ID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClassID = licenseClassID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;

        }
        public  clsLicenses()
        {
            _Mode = enMode.addnew;
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = "";
            PaidFees = 0;
            IsActive = false;
            IssueReason = enIssueReason.FirstTime;
            CreatedByUserID = -1;

        }
        public static clsLicenses FindByDriverID(int ID)
        {

            int applicationID = -1, LicenseID = -1, licenseClassID = -1;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            string note = "";
            double paidFees = 0;
            bool isActive = false;
            short issueReason = -1;
            int createdByUserID = -1;



            return clsLicenseData.GetLicenseInfoByDriverID(ref LicenseID, ref applicationID, ID, ref licenseClassID, ref issueDate, ref expirationDate,
                                                        ref note, ref paidFees, ref isActive, ref issueReason, ref createdByUserID)
                                                               ? new clsLicenses(LicenseID, applicationID, ID, licenseClassID, issueDate,
            expirationDate, note, paidFees, isActive, (enIssueReason)issueReason, createdByUserID) : null;
        }

        public static clsLicenses Find(int ID)
        {

            int applicationID = -1, driverID = -1, licenseClassID = -1;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            string note = "Without Notes";
            double paidFees = 0;
            bool isActive = false;
            short issueReason = 0;
            int createdByUserID = -1;



            return clsLicenseData.GetLicenseInfoByID(ID, ref applicationID, ref driverID, ref licenseClassID, ref issueDate, ref expirationDate,
                                                        ref note, ref paidFees, ref isActive, ref issueReason, ref createdByUserID)
                                                               ? new clsLicenses(ID, applicationID, driverID, licenseClassID, issueDate,
            expirationDate, note, paidFees, isActive, (enIssueReason)issueReason, createdByUserID) : null;
        }
        public static bool Delete(int ID)
        {
            return clsLicenseData.Delete(ID);
        }
        public static bool isLicenseExists(int ID)
        {
            return clsLicenseData.IsLicenseExists(ID);
        }
        public static bool isLicenseExistsByDriverID(int ID)
        {
            return clsLicenseData.IsLicenseExistsByDriverID(ID);
        }
        public static DataTable GetAllLicense()
        {
            return clsLicenseData.GetAllLicensseInfo();
        }
        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicenseData.GetDriversLicensseInfo(DriverID);
        }
        public DataTable GetDriverLicenses()
        {
            return clsLicenseData.GetDriversLicensseInfo(DriverID);
        }

        public bool DeactiveLicense()
        {
            return clsLicenseData.DeactiveLicense(LicenseID);
        }
        public static int GetActiveDriverLicense(int PersonID ,int LicenseClassID)
        {
            return clsLicenseData.GetActiveLicenseByPersonID(PersonID,LicenseClassID);
        }
        bool _AddNewLicense()
        {
            LicenseID = clsLicenseData.Add(ApplicationID, DriverID, LicenseClassID, ExpirationDate, Notes, PaidFees, IsActive, (short)IssueReason, CreatedByUserID);
            return LicenseID != -1;
        }
        bool _UpdateLicense()
        {
            return clsLicenseData.Update(LicenseID,ApplicationID, DriverID, LicenseClassID, ExpirationDate, Notes, PaidFees, IsActive, (short)IssueReason, CreatedByUserID);
           
        }
         public bool Save()
        {
            switch (_Mode)
            {
                case enMode.addnew:
                    if (_AddNewLicense())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else return false;

                   
                case enMode.Update:return _UpdateLicense();

                  
                default:return false;
                  
            }
        }
        public bool isLicenseExpired()
        {
            return (ExpirationDate < DateTime.Now);
        }
        public clsLicenses ReplaceLicenseForLostOrDemage(int applicationID,short IssueReason , int createdByUserID)
        {
            
            clsLicenses NewLicense = new clsLicenses();
            NewLicense.ApplicationID = applicationID;
            NewLicense.CreatedByUserID = createdByUserID;
            NewLicense.DriverID = DriverID;
            NewLicense.LicenseClassID = LicenseClassID;
            NewLicense.ExpirationDate = ExpirationDate;
            NewLicense.Notes = Notes;
            NewLicense.IsActive = IsActive;
            NewLicense.IssueDate=IssueDate;
            NewLicense.PaidFees = PaidFees;
            NewLicense.IssueReason = (enIssueReason)IssueReason;

            if (NewLicense.Save()) 
            {
                DeactiveLicense();
                return NewLicense;
            }
                  
              
            else
                return null;
        }
        public int Detain(int UserID , double Fees)
        {
            clsDetainedLicenses DetainedLicenses =new clsDetainedLicenses();
            DetainedLicenses.LicenseID = this.LicenseID; 
            DetainedLicenses.DetainDate = DateTime.Now;
            DetainedLicenses.FineFees =Fees;
            DetainedLicenses.CreatedByUserID = UserID;
            DetainedLicenses.IsReleased = false;
            if (DetainedLicenses.Save())
            {
                return DetainedLicenses.DetainID;
            }
            return -1;
        }
        public bool Rlease()
        {
            return DetainedLicensesInfo.ReleaseDetainedLicense();
        }
    }
}
