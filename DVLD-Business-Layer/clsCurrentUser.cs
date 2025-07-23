using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
     public class clsCurrentUser
    {
        public string Username
        {
            get; set;
        }
        public clsUser UserInfo
        {
            get; set;
        }
        public string Password
        {
            get; set;
        }

        public clsCurrentUser(string Username, string Password )
        {
            this.Username = Username;   
            this.Password = Password;
            this.UserInfo = clsUser.FindUser(Username);
        }
        static public bool  UpdateCurrentUser(string  Username , string password)
        {
            return clsCurrentUserData.UpdateCurrentUser(Username, password);
            
        }
        static public clsCurrentUser  GetCurrentUser()
        {
            string Password = "", Username = "";
            

                return clsCurrentUserData.GetCurrentUser(ref Username, ref Password) ?
                new clsCurrentUser(Username, Password) : null;
        }  

      }
}
