using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsApplicationTypes
    {
        public int ID
        {
            get; set;
        }
        public string Title
        {
            get; set;
        }
        public double FeeS
        {
            get; set;
        }
        clsApplicationTypes(int ApplicationID, string ApplicationTitle, double ApplicationFees)
        {
            ID = ApplicationID;
            Title = ApplicationTitle;
            FeeS = ApplicationFees;
        }
        public static DataTable GetAll()
        {
            return clsApplicationTypesData.All();
        }
        bool _Update()
        {
            return clsApplicationTypesData.UpdateApplicationFees(this.ID, this.Title,this.FeeS);
        }
        public bool Save()
        {
            return _Update();
        }
        public static clsApplicationTypes Find(int ID)
        {
            string Title = "";
            double ApplicationFees = -1;
            return clsApplicationTypesData.FindApplicationType(ID, ref Title, ref ApplicationFees) ? new clsApplicationTypes(ID, Title, ApplicationFees) : null;
        }
        public static clsApplicationTypes Find(string TestType)
        {
            int ID = -1;
            double ApplicationFees = -1;
            return clsApplicationTypesData.FindApplicationTypeByTitle(ref ID, TestType, ref ApplicationFees) ? new clsApplicationTypes(ID, TestType, ApplicationFees) : null;
        }
    }
}
