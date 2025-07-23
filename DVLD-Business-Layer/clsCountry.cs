using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsCountry
    {
        public string CountryName { get; set; }
        public int CountryID { get; set; }

        clsCountry(int ID,string Name)
        {
            this.CountryName = Name;
            this.CountryID = ID;

        }
        static public DataTable GetAllCountries()
        {
            return clsCountrydata.GetAllCountries();

        }
        public static clsCountry Find(string CountryName)
        {
            int Id = -1;
            return clsCountrydata.GetCountryByName(ref Id, CountryName) ? new clsCountry(Id, CountryName) : null;
        }
        public static clsCountry Find(int ID)
        {
            string CountryName="";
            return clsCountrydata.GetCountryByID( ID,ref CountryName) ? new clsCountry(ID, CountryName) : null;
        }
    }
}
