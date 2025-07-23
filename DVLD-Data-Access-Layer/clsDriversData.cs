using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public class clsDriversData
    {
        /*
         SELECT TOP (1000) [DriverID]
      ,[PersonID]
      ,[CreatedByUserID]
      ,[CreatedDate]
  FROM [DVLD].[dbo].[Drivers]

         */
        static public bool GetDriverInfoByID(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;
            string Query = @" 
                             select * from Drivers where DriverID=@DriverID;
                            ";
            SqlConnection connection =new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand Command=new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("DriverID", DriverID);
            try
            {
                connection.Open();
                SqlDataReader reader=Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
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
        static public bool GetDriverInfoByPersonID(ref int DriverID, int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;
            string Query = @" 
                             select * from Drivers where PersonID=@PersonID;
                            ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    DriverID = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
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
        static public DataTable GetAllDriversInfo()
        {
            DataTable dt = new DataTable();
            string Query = @" 
                             select * from Drivers_View;
                            ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand Command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        static public bool UpdateDriverInfo( int DriverID, int PersonID,  int CreatedByUserID)
        {
            int RowEffect = -1;

            string Query = @" update Drivers set 
 
                                                     PersonID=@PersonID
                                                     CreatedByUserID=@CreatedByUserID
                                                     CreatedDate=@CreatedDate where 
                                                     DriverID=@DriverID
                            ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("DriverID", DriverID);
            Command.Parameters.AddWithValue("PersonID", PersonID);
            Command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("CreatedDate", DateTime.Now);
            try
            {
                connection.Open();
                RowEffect = Command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return RowEffect!=-1;
        }
        static public int AddNewDriver( int PersonID,  int CreatedByUserID)
        {
            int ID = -1;

            string Query = @" insert into Drivers Values( 
 
                                                     @PersonID,
                                                     @CreatedByUserID,
                                                     @CreatedDate 
                                                     ); select SCOPE_IDENTITY();
                            ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("PersonID", PersonID);
            Command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("CreatedDate", DateTime.Now);
            try
            {
                connection.Open();
                object reader = Command.ExecuteScalar();
                if (reader!=null && int. TryParse(reader.ToString(),out int NewID))
                {
                    ID = NewID;
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return ID;
        }
        static public bool DeleteDriverInfo(int DriverID)
        {
            int RowEffect = -1;

            string Query = @" Delete from Drivers where 
                                                     DriverID=@DriverID
                            ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("DriverID", DriverID);
            try
            {
                connection.Open();
                RowEffect = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return RowEffect != -1;
        }





    }
}
