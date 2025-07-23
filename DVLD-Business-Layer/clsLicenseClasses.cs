using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
     public class clsLicenseClasses
    {
       
        public string ClassName
        {
            set; get;
        }
        public int MinimumAllowedAge
        {
            set; get;
        }
        public double ClassFees
        {
            set; get;
        }
        public int DefaultValidityLength
        {
            set; get;
        }
        string ClassDescription
        {
            set; get;
        }
        public int LicenseClassID
        {
            set; get;
        }
        private clsLicenseClasses(int ID, string LicenseClassName ,string classDescription , int minimumAllowedAge ,int defaultValidityLength , double Fees)
        {
            LicenseClassID = ID;
            ClassName = LicenseClassName;
            ClassFees = Fees;
            ClassDescription = classDescription;
            MinimumAllowedAge = minimumAllowedAge;
            DefaultValidityLength = defaultValidityLength;

        }
        public static clsLicenseClasses Find(int ID)
        {

            string ClassName = "", ClassDescription = "";
            double ClassFees = 0;

            int MinimumAllowedAge = 18,defaultValidityLength= 10; 
             
             
            return clsLicenseClassData.GetLicenseClassesByID(ID, ref ClassName, ref ClassDescription  ,ref MinimumAllowedAge , ref defaultValidityLength, ref ClassFees) ? new clsLicenseClasses(ID, ClassName , ClassDescription,  MinimumAllowedAge,  defaultValidityLength,  ClassFees) : null;
        }
        public static DataTable GetLicensesClassesNames()
        {
            return clsLicenseClassData.getAll();
        }
        public static DataTable GetAllLicensesClasses()
        {
            return clsLicenseClassData.getAllLicensesClassesInfo();
        }
    }
}
