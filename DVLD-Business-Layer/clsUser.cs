using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    
    public class clsUser
    {
        enum enMode
        {
            Addnew = 0, Update = 1
        }
        enMode _mode = enMode.Addnew;
        public int UserID
        {
            get; set;
        }
        public clsPeople PeopleInfo
        { get; set; }
        
        public int PersonID
        {
            get; set;
        }
        public string UserName
        {
            get; set;
        }
        public string Password
        {
            get; set;
        }
       
        public bool isActive
        {
            get; set;
        }
        public clsUser()
        {
            this._mode = enMode.Addnew;
            this.UserID = -1;
            this.PersonID = -1;
            this.isActive = false;
            this.Password = string.Empty;
            this.UserName = string.Empty;
            this.PeopleInfo = null;
            
        }
        clsUser(int UserID, int PersonID, string UserName, string Password, bool isActive)
        {
            this._mode = enMode.Update;
            this.UserID =UserID;
            this.PersonID = PersonID;
            this.isActive = isActive;
            this.Password = Password;
            this.UserName = UserName;
           
            this.PeopleInfo = clsPeople.FindPerson(PersonID);

        }

        static public DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }
        bool _UpdateUser()
        {
            return clsUsersData.UpdateUserInformation(this.UserID, this.PersonID, this.UserName, this.Password, this.isActive);
        
        }
        bool _AddNewUser()
        {
            UserID = clsUsersData.AddNewUser(this.PersonID, this.UserName, this.Password, this.isActive);
            return PersonID != -1;

        }
        public bool Save()
        {
            switch (_mode)
            {
                case enMode.Addnew:
                    if (_AddNewUser())
                    {
                        _mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateUser();

                default:
                    break;

            }
            return false;

        }
        static public clsUser FindUser(int UserID)
        {
            string UserName = "", Password = ""; 
            int PersonID = -1;
            bool isActive = false;
            return clsUsersData.GetUserByID(UserID, ref PersonID, ref UserName, ref Password, ref isActive) ?

                new clsUser(UserID, PersonID, UserName, Password, isActive) : null;
           
        }
        static public clsUser FindUser(string Username)
        {
            string Password = "";
            int UserID = -1, PersonID = -1;
            bool isActive = false;
            return clsUsersData.GetUserByUsername(Username,ref UserID,ref PersonID, ref Password, ref isActive) ?

                new clsUser(UserID, PersonID, Username, Password, isActive) : null;



        }
        static public clsUser FindUserByPersonID(int PersonID)
        {
            string UserName = "", Password = "";
            int UserID = -1;
            bool isActive = false;
            return clsUsersData.GetUserByPersonID(ref UserID, PersonID, ref UserName, ref Password, ref isActive) ?

                new clsUser(UserID, PersonID, UserName, Password, isActive) : null;



        }
        static public clsUser FindUserByUsernameAndPassword(string Username , string Password)
        {
            
            int UserID = -1,  PersonID = -1;
            bool isActive = false;
            return clsUsersData.GetUserByUsernameAndPassword(Username,Password , ref UserID, ref PersonID, ref isActive) ?

                new clsUser(UserID, PersonID, Username, Password, isActive) : null;



        }
        public static bool IsUserExists(int UserID)
        {
            return clsUsersData.isUserExists(UserID);
        }
        public static bool IsUserActive(int UserID)
        {
            return clsUsersData.isUserActive(UserID);
        }
        public static bool IsUserExistsbyPersonID(int PersonID)
        {
            return clsUsersData.isUserExistsByPersonID(PersonID);
        }
        public static bool DeleteUser(int UserID)
        {
            return clsUsersData.DeleteUserInformation(UserID);
        }

        

    }
}
