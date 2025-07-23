using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsDetainedLicenses
    {
            // ref DateTime DetainDate, ref double FineFees, ref int CreatedByUserID
            //,ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID
        public int DetainID
        {
            get; set;
        }
        public int CreatedByUserID
        {
            get; set;
        }
        public int LicenseID
        {
            get; set;
        }
        public clsLicenses LicenseInfo
        {
            get; set;
        }
        public DateTime DetainDate
        {
            get; set;
        }
        public DateTime ReleaseDate
        {
            get; set;
        }
        public double FineFees
        {
            get; set;
        }
        public bool IsReleased
        {
            get; set;
        }
        public clsApplication ReleaseApplicationInfo
        {
            get; set;
        }
        public int ReleaseApplicationID
        {
            get; set;
        }
        public int ReleasedByUserID
        {
            get; set;
        }
        enum enMode
        {
            addNew=0,Update=1
        }
        enMode _Mode=enMode.addNew;
        public clsDetainedLicenses()
        {
             _Mode = enMode.addNew;

            this.DetainID = -1;
            this.CreatedByUserID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = 0;
            this.IsReleased = false;
                this.ReleaseApplicationID = -1;
                this.ReleasedByUserID = -1;

        }
        public clsDetainedLicenses(int DetainID,int LicenseID,DateTime DetainDate,  double FineFees,  int CreatedByUserID
            , bool IsReleased,  DateTime ReleaseDate,  int ReleasedByUserID,  int ReleaseApplicationID)
        {
            _Mode = enMode.Update;
            this.DetainID = DetainID;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.ReleaseDate = ReleaseDate;
            this.FineFees = FineFees;
            this.IsReleased = IsReleased;
            this.ReleaseApplicationID = ReleaseApplicationID;
            this.ReleasedByUserID = ReleasedByUserID;
            LicenseInfo=clsLicenses.Find(DetainID);
            ReleaseApplicationInfo=clsApplication.FindBaseApplication(ReleaseApplicationID);


        }

        bool _Update()
        {
            return clsDetainedLicensesData.UpdateDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
        }
        bool _AddNew()
        {
            DetainID = clsDetainedLicensesData.AddNewDetainedLicense(LicenseID, FineFees, CreatedByUserID);
            return DetainID != -1;
        }
        public bool Delete()
        {
            return clsDetainedLicensesData.DeleteDetainedLicense(DetainID);
        }
        public static bool Delete(int DetainID)
        {
            return clsDetainedLicensesData.DeleteDetainedLicense(DetainID);
        }
        public bool DeleteByLicenseID()
        {
            return clsDetainedLicensesData.DeleteDetainedLicenseByLicenseID(LicenseID);
        }
        public static bool DeleteByLicenseID(int LicenseID)
        {
            return clsDetainedLicensesData.DeleteDetainedLicenseByLicenseID(LicenseID);
        }
        public static DataTable GetAll()
        {
            return clsDetainedLicensesData.GetDetainedLicenses();
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.addNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:return _Update();
                   
                default:return false;
                 
            }
        }
        public  bool isDetainedLicenses()
        {
            return clsDetainedLicensesData.isLicenseDetained(LicenseID);
        }
        public static clsDetainedLicenses Find(int ID)
        {
            int CreatedByUserID = -1,
            LicenseID = -1;
            DateTime DetainDate = DateTime.Now, ReleaseDate = DateTime.Now;
            double FineFees = 0;
            bool IsReleased = false;
            int ReleaseApplicationID = -1, ReleasedByUserID = -1;
            return clsDetainedLicensesData.GetDetainedLicenseByID(ID, ref LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID
            , ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID) ? new clsDetainedLicenses(ID, LicenseID, DetainDate, FineFees, CreatedByUserID
            , IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID) : null;
        }
        public static clsDetainedLicenses FindByLicenseID(int LicenseID)
        {
            int CreatedByUserID = -1,
            DetainID = -1;
            DateTime DetainDate = DateTime.Now, ReleaseDate = DateTime.Now;
            double FineFees = 0;
            bool IsReleased = false;
            int ReleaseApplicationID = -1, ReleasedByUserID = -1;
            return clsDetainedLicensesData.GetDetainedLicenseByLicenseID(ref DetainID, LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID
            , ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID) ? new clsDetainedLicenses(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID
            , IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID) : null;
        }
        public static clsDetainedLicenses FindByReleaseApplicationID(int ReleaseApplicationID)
        {
            int CreatedByUserID = -1,
            DetainID = -1;
            DateTime DetainDate = DateTime.Now, ReleaseDate = DateTime.Now;
            double FineFees = 0;
            bool IsReleased = false;
            int LicenseID = -1, ReleasedByUserID = -1;
            return clsDetainedLicensesData.GetDetainedLicenseByReleaseID(ref DetainID, ref LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID
            , ref IsReleased, ref ReleaseDate, ref ReleasedByUserID,  ReleaseApplicationID) ? new clsDetainedLicenses(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID
            , IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID) : null;
        }
        public bool ReleaseDetainedLicense()
        {
            return clsDetainedLicensesData.ReleaseDetainedLicense(DetainID, ReleasedByUserID, ReleaseApplicationID);
        }
        public static bool ReleaseDetainedLicense(int DetainID, int ReleasedByUserID,int  ReleaseApplicationID)
        {
            return clsDetainedLicensesData.ReleaseDetainedLicense(DetainID, ReleasedByUserID, ReleaseApplicationID);
        }
        public static bool isDetainedLicenses(int LicenseID)
        {
            return clsDetainedLicensesData.isLicenseDetained(LicenseID);
        }

    }
}
