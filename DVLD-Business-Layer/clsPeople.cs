using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access_Layer;
namespace DVLD_Business_Layer
{
    public class clsPeople
    {
        enum enMode
        {
            Addnew = 0, Update = 1
        }
        enMode _mode = enMode.Addnew;
        public string FirstName
        {
            get; set;
        }
        public clsCountry CountryInfo
        { get; set; }
        public string SecondName
        {
            get; set;
        }
        public string ThirdName
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        public string fullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }
        }
        public int PersonID
        {
            get; set;
        }
        public string Email
        {
            get; set;
        }
        public string Address
        {
            get; set;
        }
        public string Phone
        {
            get; set;
        }
        public string ImagePath
        {
            get; set;
        }
        public string NationalNo
        {
            get; set;
        }
        public int CountryID
        {
            get; set;
        }
        public DateTime DateOfBirth
        {
            get; set;
        }
        public short Gendor
        {
            get; set;
        }
        public clsPeople()
        {
            this._mode = enMode.Addnew;
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.SecondName = string.Empty;
            this.ThirdName = string.Empty;
            this.DateOfBirth = DateTime.Now;
            this.PersonID = -1;
            this.CountryID = -1;
            this.Gendor = -1;
            this.NationalNo = string.Empty;
            this.ImagePath = string.Empty;
            this.Email = string.Empty;
            this.Phone = string.Empty;
            this.Address = string.Empty;
            this.CountryInfo = null;
            ;
        }
        clsPeople(int ID, string NationalNo, string FirstName, string SecondName, string ThridName,
             string LastName, DateTime DateOfBirth, short Gendor, string Address,
             string Email, string Phone, int CountryID, string ImagePath)
        {
            _mode = enMode.Update;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.SecondName = SecondName;
            ThirdName = ThridName;
            this.DateOfBirth = DateOfBirth;
            this.PersonID = ID;
            this.CountryID = CountryID;
            this.Gendor = Gendor;
            this.NationalNo = NationalNo;
            this.ImagePath = ImagePath;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            CountryInfo = clsCountry.Find(CountryID);

        }

        static public DataTable GetAllPeople()
        {
            return clsPeopleData.GetAll();
        }
        bool _UpdatePerson()
        {
            return clsPeopleData.UpdatePersonInformation(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
        this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Email, this.Phone, this.CountryID, this.ImagePath);
        }
        bool _AddNewPerson()
        {
            PersonID = clsPeopleData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Email, this.Phone, this.CountryID, this.ImagePath);
            return PersonID != -1;

        }
        public bool Save()
        {
            switch (_mode)
            {
                case enMode.Addnew:
                    if (_AddNewPerson())
                    {
                        _mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePerson();

                default:
                    break;

            }
            return false;

        }
        static public clsPeople FindPerson(int ID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "",
                Email = "", Phone = "", Address = "", ImagePath = "";
            int CountryID = -1;
            short Gendor = -1;

            DateTime DateOfBirth = DateTime.Now;
            return clsPeopleData.GetPersonByID(ID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName,
             ref LastName, ref DateOfBirth, ref Gendor, ref Address,
             ref Email, ref Phone, ref CountryID, ref ImagePath) ?

               new clsPeople(ID, NationalNo, FirstName, SecondName, ThirdName,
              LastName, DateOfBirth, Gendor, Address,
              Email, Phone, CountryID, ImagePath) : null;


        }
        static public clsPeople FindPerson(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "",
                Email = "", Phone = "", Address = "", ImagePath = "";
            int ID = -1, CountryID = -1;
            short Gendor = -1;
            DateTime DateOfBirth = DateTime.Now;
            return (clsPeopleData.GetPersonByNationalNo(ref ID, NationalNo, ref FirstName, ref SecondName, ref ThirdName,
             ref LastName, ref DateOfBirth, ref Gendor, ref Address,
             ref Email, ref Phone, ref CountryID, ref ImagePath)) ? new clsPeople(ID, NationalNo, FirstName, SecondName, ThirdName,
              LastName, DateOfBirth, Gendor, Address,
              Email, Phone, CountryID, ImagePath) : null;


        }
        public static bool IsExists(int ID)
        {
            return clsPeopleData.isPersonExists(ID);
        }
        public static bool IsExists(string NationalNo)
        {
            return clsPeopleData.isPersonExists(NationalNo);
        }
        public static bool DeletePerson(int PersonID)
        {
            return clsPeopleData.DeletePersonInformation(PersonID)&&!clsUser.IsUserExistsbyPersonID(PersonID);
        }

    }
}
