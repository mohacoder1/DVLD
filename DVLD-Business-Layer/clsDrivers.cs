using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public  class clsDrivers
    {
        enum enMode
        {
            addNew=0,Update=1
        }
        enMode _Mode= enMode.addNew;
        public int DriverID
        {
            get; set;
        }
        public int PersonID
        {
            get; set;
        }
        public int CreatedByUserID
        {
            get; set;
        }
        public DateTime CreatedDate
        {
            get; set;
        }
        public clsPeople PersonInfo
        {
            get; set;
        }
        public clsUser UserInfo
        {
            get; set;
        }

        public clsDrivers()
        {
            _Mode = enMode.addNew;
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;

        }
        public clsDrivers(int driverID,int personID,int UserID, DateTime Date )
        {
            _Mode = enMode.Update;
            DriverID = driverID;
            PersonID = personID;
            CreatedByUserID = UserID;
            CreatedDate = Date;
            PersonInfo = clsPeople.FindPerson(personID);
            UserInfo= clsUser.FindUser(UserID);
        }

        bool _AddNewDriver()
        {
            DriverID = clsDriversData.AddNewDriver(PersonID, CreatedByUserID);
            return DriverID != -1;
        }
        bool _UpdateDriver()
        {
            return  clsDriversData.UpdateDriverInfo(DriverID, PersonID, CreatedByUserID);
            
        }
        public static bool DeleteDriver(int ID)
        {
            return clsDriversData.DeleteDriverInfo(ID);
        }
        public static DataTable GetAllDriver()
        {
            return clsDriversData.GetAllDriversInfo();
        }
  
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.addNew:
                    if (_AddNewDriver())
                    {
                        _Mode = enMode.Update;
                        return true; 
                    }
                    else
                    return false;

                case enMode.Update: return _UpdateDriver();
                    
                default:return false;
                   
            }
        }

        public static clsDrivers Find(int ID)

        {
            int PersonID = -1, User = -1;
            DateTime CreatedDate = DateTime.Now;
            return clsDriversData.GetDriverInfoByID(ID, ref PersonID, ref User, ref CreatedDate) ? new clsDrivers(ID, PersonID, User, CreatedDate) : null;
        }
        public static clsDrivers FindByPerson(int PersonID)

        {
            int ID = -1, User = -1;
            DateTime CreatedDate = DateTime.Now;
            return clsDriversData.GetDriverInfoByPersonID(ref ID,  PersonID, ref User, ref CreatedDate) ? new clsDrivers(ID, PersonID, User, CreatedDate) : null;
        }


    }
}
