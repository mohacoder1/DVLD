using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_Business_Layer
{
    public class clsTestTypes
    {
        public enum enTestType
        {
            Vision = 1, Written = 2, Street = 3
        }
       
        public enTestType ID
        {
            get; set;
        }
        public string TestTitle
        {
            get; set;
        }
        public string TestDesc
        {
            get; set;
        }
        public double Fees
        {
            get; set;
        }
        clsTestTypes(enTestType testID, string testTitle, string testDesc, double fees)
        {
            ID = testID;
            TestTitle = testTitle;
            TestDesc = testDesc;
            Fees = fees;
        }
        public static DataTable GetAll()
        {
            return clsTestTypesData.All();
        }
        bool _UpdateTestFees()
        {
            return clsTestTypesData.UpdateTestFees((int)ID, this.Fees);
        }
        public bool Save()
        {
            return _UpdateTestFees();
        }
        public static clsTestTypes Find(int ID)
        {
            double Fees = -1;
            string Title = "", Desc = "";
            return clsTestTypesData.GetTestTypes(ID, ref Title, ref Desc, ref Fees) ? new clsTestTypes((enTestType)ID, Title, Desc, Fees) : null;
        }
    }
}
