using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public static class clsPeopleData
    { 
        public static bool GetPersonByID(int PersonID, ref string NationalNo , ref string FirstName , ref string SecondName, ref string ThridName,
            ref string LastName , ref DateTime DateOfBirth, ref short Gendor , ref string Address ,
            ref string Email, ref string Phone ,ref int CountryID , ref string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            bool isFound = false;
            string Query = "select * from People where PersonID=@PersonID";
            SqlCommand cmd = new SqlCommand(Query,connection);
            cmd.Parameters.AddWithValue("PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    CountryID = (int)reader["NationalityCountryID"];
                    Phone = (string)reader["Phone"] ;
                    ThridName = (string)reader["ThirdName"] ?? "";
                    Email = (string)reader["Email"] ?? "";
                    ImagePath = (string)reader["ImagePath"] ?? "";
                  
                }
            }
            catch(Exception ex)
            {
               
            }
            finally
            {
                connection.Close();
            }
           
            return isFound;
        }

        public static bool GetPersonByNationalNo(ref int ID, string NationalNo, ref string FirstName, ref string SecondName, ref string ThridName,
            ref string LastName, ref DateTime DateOfBirth, ref short Gendor, ref string Address,
            ref string Email, ref string Phone, ref int CountryID, ref string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            bool isFound = false;
            string Query = "select * from People where NationalNo=@NationalNo";
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("NationalNo", NationalNo);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    isFound = true;
                    ID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThridName = (string)reader["ThirdName"] ?? "";//null
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    CountryID = (int)reader["NationalityCountryID"];
                    Email = (string)reader["Email"] ?? "";//null
                    Phone = (string)reader["Phone"];
                    ImagePath = (string)reader["ImagePath"] ?? "";//null
                }
            }
            catch (Exception ex)
            {
                

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static DataTable GetAll()
        {
            DataTable dtPeople = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = "select * from vPeople";
            SqlCommand cmd = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    dtPeople.Load(sqlDataReader);
                }
                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                dtPeople = new DataTable();
            }
            finally {
                connection.Close(); 
            }
            return dtPeople;
        }
        public static int AddNewPerson( string NationalNo,  string FirstName,  string SecondName, string ThirdName,
            string LastName,  DateTime DateOfBirth, short Gendor, string Address,
            string Email,  string Phone,  int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query =
                "INSERT INTO [dbo].[People] ([NationalNo],[FirstName],[SecondName]" +
                ",[ThirdName],[LastName],[DateOfBirth],[Gendor],[Address],[Phone],[Email],[NationalityCountryID],[ImagePath]) VALUES" +
                " (@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth ,@Gendor,@Address, @Phone,@Email,@NationalityCountryID," +
                " @ImagePath);select SCOPE_IDENTITY(); ";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue( "@NationalNo",(object)NationalNo);
            cmd.Parameters.AddWithValue( "@FirstName", (object)FirstName);
            cmd.Parameters.AddWithValue("@SecondName", (object)SecondName);
            cmd.Parameters.AddWithValue("@ThirdName",(object)ThirdName?? DBNull.Value); 
            cmd.Parameters.AddWithValue("@LastName", (object)LastName);     
            cmd.Parameters.AddWithValue("@DateOfBirth", (object)DateOfBirth);
            cmd.Parameters.AddWithValue("@Gendor", (object)Gendor);
            cmd.Parameters.AddWithValue("@Address", (object)Address);
            cmd.Parameters.AddWithValue("@Phone", (object)Phone);
            cmd.Parameters.AddWithValue("@Email", (object)Email ?? DBNull.Value); 
            cmd.Parameters.AddWithValue("@NationalityCountryID", (object)NationalityCountryID);
            cmd.Parameters.AddWithValue("@ImagePath",(object)ImagePath ??DBNull.Value);
            try
            {

                connection.Open();
                object result=cmd.ExecuteScalar();
                if (result!=null&&int.TryParse(result.ToString() ,out int newID ))
                {
                    PersonID = newID;
                }
                else
                {
                    PersonID = -1;    
                }
            }
            catch(Exception)
            {
                PersonID = -1;
            }
            finally
            {
                connection.Close();
            }
            return PersonID;
        }
       
        public static bool UpdatePersonInformation( int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, short Gendor, string Address,
            string Email, string Phone, int NationalityCountryID, string ImagePath)
        {
            int RowEffected = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query =
                @"Update people set 
NationalNo=@NationalNo,
FirstName=@FirstName,
SecondName =@SecondName,
ThirdName=@ThirdName,
LastName=@LastName,
Phone=@Phone,
Address=@Address,
Email=@Email,
ImagePath=@ImagePath,
NationalityCountryID=@NationalityCountryID,
Gendor=@Gendor,
DateOfBirth=@DateOfBirth 
where PersonID=@PersonID";
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@PersonID", (object)PersonID);
            cmd.Parameters.AddWithValue("@NationalNo", (object)NationalNo);
            cmd.Parameters.AddWithValue("@FirstName", (object)FirstName);
            cmd.Parameters.AddWithValue("@SecondName", (object)SecondName);
            cmd.Parameters.AddWithValue("@ThirdName", (object)ThirdName ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@LastName", (object)LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", (object)DateOfBirth);
            cmd.Parameters.AddWithValue("@Gendor", (object)Gendor);
            cmd.Parameters.AddWithValue("@Address", (object)Address);
            cmd.Parameters.AddWithValue("@Phone", (object)Phone);
            cmd.Parameters.AddWithValue("@Email", (object)Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@NationalityCountryID", (object)NationalityCountryID);
            cmd.Parameters.AddWithValue("@ImagePath", (object)ImagePath ?? DBNull.Value);
            try
            {

                connection.Open();
                RowEffected = cmd.ExecuteNonQuery();
               
            }
            catch (Exception)
            {
                RowEffected = -1;
            }
            finally
            {
                connection.Close();
            }
            return RowEffected!=-1;
        }
      
        
        public static bool DeletePersonInformation(int PersonID)
        {
            int Rows = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = "delete from People where PersonID=@PersonID";
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("PersonID", PersonID);
            try
            {
                connection.Open();
                Rows = cmd.ExecuteNonQuery();
                
            }
            catch (Exception)
            {
                Rows = -1;
            }
            finally
            {
                connection.Close();
            }
            return Rows!=-1;
        }
        public static bool isPersonExists(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = "select Found=1 from People where PersonID=@PersonID";
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("PersonID", PersonID);
            try
            {
                connection.Open();
                object reader = cmd.ExecuteScalar();
                if (reader != null)
                {
                    isFound = true;
                }
            }
            catch (Exception)
            {

                isFound = false; 
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static bool isPersonExists(string NationalNo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = "select Found=1 from People where NationalNo=@NationalNo";
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("NationalNo", NationalNo);
            try
            {
                connection.Open();
                object reader = cmd.ExecuteScalar();
                if (reader != null)
                {
                    isFound = true;
                }
            }
            catch (Exception)
            {

                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

    }
}
