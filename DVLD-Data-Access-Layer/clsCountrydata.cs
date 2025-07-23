using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public class clsCountrydata
    {
        public static bool GetCountryByID(int CountryID, ref string CountryName)
        {
            bool isFound=false;
            string query = "Select * from Countries where CountryID=@CountryID;";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("CountryID", CountryID);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    CountryName = (string)reader["CountryName"];
                }
                else
                {
                    isFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
            public static bool GetCountryByName(ref int ID, string CountryName)
        {
            bool isFound = false;
            string query = "Select * from Countries where CountryName=@CountryName";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("CountryName", CountryName);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ID = (int)reader["CountryID"];
                }
                else
                {
                    isFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static DataTable GetAllCountries()
        {
            DataTable dataTable = new DataTable();  
            string query = "Select * from Countries";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dataTable.Load(reader);

                }
                
                reader.Close();
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                connection.Close();
            }
           return dataTable;
        }
    }
}
