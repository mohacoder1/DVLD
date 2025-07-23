using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
     public static class clsUsersData
    {
        //Get Operations
        public static bool GetUserByID(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool isActive) 
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            bool isFound = false;
            string Query = "select * from Users where UserID=@UserID";
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("UserID", UserID);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    isActive = (bool)reader["isActive"];
                   
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool GetUserByUsername( string UserName,ref int UserID,ref int PersonID,  ref string Password, ref bool isActive) 
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            bool isFound = false;
            string Query = "select * from Users where UserName=@UserName";
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    isFound = true;
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    Password = (string)reader["Password"];
                    isActive = (bool)reader["isActive"];

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
        public static bool GetUserByPersonID(ref int UserID, int PersonID, ref string UserName, ref string Password, ref bool isActive) 
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            bool isFound = false;
            string Query = "select * from Users where PersonID=@PersonID";
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    isFound = true;
                    UserID = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    isActive = (bool)reader["isActive"]; ;

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
        public static bool GetUserByUsernameAndPassword(string UserName,string Password,ref int UserID,ref int PersonID, ref bool isActive)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            bool isFound = false;
            string Query = "select * from Users where UserName=@UserName And Password=@Password";
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("UserName", UserName);
            cmd.Parameters.AddWithValue("Password", Password);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    isFound = true;
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    isActive = (bool)reader["isActive"];

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
        public static DataTable GetAllUsers()
        {
            DataTable dtUsers = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = "  SELECT * from vUser   ";
            SqlCommand cmd = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    dtUsers.Load(sqlDataReader);
                }
                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                dtUsers = new DataTable();
            }
            finally
            {
                connection.Close();
            }
            return dtUsers;
        }

        //Add Update operations
        public static int AddNewUser(int PersonID,  string UserName,  string Password,  bool isActive)
        {
            int UsersID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query =
                "INSERT INTO Users (PersonID,UserName,Password,isActive) VALUES" +
                " (@PersonID,@UserName,@Password,@isActive);select SCOPE_IDENTITY(); ";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@PersonID", (object)PersonID);
            cmd.Parameters.AddWithValue("@UserName", (object)UserName);
            cmd.Parameters.AddWithValue("@Password", (object)Password);
            cmd.Parameters.AddWithValue("@isActive", (object)isActive );
            
            try
            {

                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int newID))
                {
                    UsersID = newID;
                }
                else
                {
                    UsersID = -1;
                }
            }
            catch (Exception)
            {
                UsersID = -1;
            }
            finally
            {
                connection.Close();
            }
            return UsersID;
        }
        public static bool UpdateUserInformation(int UserID, int PersonID, string UserName, string Password, bool isActive)
        {
            int RowEffected = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query =
                @"Update Users set 
                PersonID=@PersonID,
                UserName =@UserName,
                isActive=@isActive,
                Password=@Password
                where UserID=@UserID";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@PersonID", (object)PersonID);
            cmd.Parameters.AddWithValue("@UserID", (object)UserID);
            cmd.Parameters.AddWithValue("@UserName", (object)UserName);
            cmd.Parameters.AddWithValue("@Password", (object)Password);
            cmd.Parameters.AddWithValue("@isActive", (object)isActive );

         
            try
            {

                connection.Open();
                RowEffected = cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                //RowEffected = -1;
            }
            finally
            {
                connection.Close();
            }
            return RowEffected != -1;
        }


        //Delete operation
        public static bool DeleteUserInformation(int UserID)
        {
            int Rows = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = "delete from Users where UserID=@UserID";
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("UserID", UserID);
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
            return Rows != -1;
        }
        //User existance
        public static bool isUserExistsByPersonID(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = "select Found=1 from Users where PersonID=@PersonID";
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
        public static bool isUserExists(int UserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = "select Found=1 from Users where UserID=@UserID";
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("UserID", UserID);
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
        public static bool isUserExists(string UserName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = "select Found=1 from Users where UserName=@UserName";
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("UserName", UserName);
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
        //User activation
        public static bool isUserActive(int UserID)
        {
            bool isActive = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = "select Found=1 from Users where UserID=@UserID And isActive=1";
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("UserID", UserID);
            try
            {
                connection.Open();
                object reader = cmd.ExecuteScalar();
                if (reader != null)
                {
                    isActive = true;
                }
            }
            catch (Exception)
            {

                isActive = false;
            }
            finally
            {
                connection.Close();
            }
            return isActive;
        }
        public static bool isUserActive(string UserName)
        {
            bool isActive = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = "select Found=1 from Users where UserName=@UserName And isActive=1";
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("UserName", UserName);
            try
            {
                connection.Open();
                object reader = cmd.ExecuteScalar();
                if (reader != null)
                {
                    isActive = true;
                }
            }
            catch (Exception)
            {

                isActive = false;
            }
            finally
            {
                connection.Close();
            }
            return isActive;
        }

      
    }
}
