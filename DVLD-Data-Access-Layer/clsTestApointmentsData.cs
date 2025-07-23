using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public class clsTestApointmentsData
    {
        public static bool GetTestApointmentByID(int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID,
            ref DateTime AppointmentDate, ref double PaidFees, ref int CreatedByUserID, ref bool isLocked, ref int RetakeTestApplicationID)
        {
            bool isFound = false;
            string Query = @"
                           SELECT * FROM TestAppointments where TestAppointmentID=@TestAppointmentID ;";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = Convert.ToDouble(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    isLocked = (bool)reader["isLocked"];
                    RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];

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
        public static bool GetLastTestApointment(ref int TestAppointmentID, int TestTypeID,  int LocalDrivingLicenseApplicationID,
                   ref DateTime AppointmentDate, ref double PaidFees, ref int CreatedByUserID, ref bool isLocked, ref int RetakeTestApplicationID)
        {
            bool isFound = false;
            string Query = @"
                          
		   select  top 1 * from TestAppointments where 
		   LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID and 
		   TestTypeID=@TestTypeID order by TestAppointmentID desc ;";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = Convert.ToDouble(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    isLocked = (bool)reader["isLocked"];
                    RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];

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

        public static DataTable GetAllTestApointment()
        {
           DataTable dt=new DataTable();

            string Query = @"
                           SELECT * FROM TestAppointments_View order by AppointmentDate desc;";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
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
        public static DataTable GetApplicationTestApointmentPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DataTable dt = new DataTable();

            string Query = @"
                             SELECT TestAppointmentID,AppointmentDate,PaidFees,IsLocked FROM TestAppointments where TestTypeID=@TestTypeID and 
                            LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID order by AppointmentDate Desc";

                           
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand command = new SqlCommand(Query, connection);
           command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
           command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
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

        public static int AddNewTestApointment(int TestTypeID, int LocalDrivingLicenseApplicationID,
             DateTime AppointmentDate, double PaidFees, int CreatedByUserID, bool isLocked, int RetakeTestApplicationID)
        {
            int ID = -1;
            string Query = @"
                           INSERT INTO TestAppointments
           (TestTypeID
           ,LocalDrivingLicenseApplicationID
           ,AppointmentDate
           ,PaidFees
           ,CreatedByUserID
           ,IsLocked
           ,RetakeTestApplicationID)

     VALUES
	      (@TestTypeID
           ,@LocalDrivingLicenseApplicationID
           ,@AppointmentDate
           ,@PaidFees
           ,@CreatedByUserID
           ,@IsLocked
           ,@RetakeTestApplicationID);
		   select SCOPE_IDENTITY();

           ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", (decimal)PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@isLocked", isLocked);
            if (RetakeTestApplicationID == -1)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

            }
            try
            {
                connection.Open();
                object reader = command.ExecuteScalar();
                if (reader != null && int.TryParse(reader.ToString(), out int NewID))
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
        public static bool UpdateTestApointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID,
                   DateTime AppointmentDate, double PaidFees, int CreatedByUserID, bool isLocked, int RetakeTestApplicationID)
        {
            int RowEffect = -1;
            string Query = @"
                          Update TestAppointments set
           TestTypeID=@TestTypeID
           ,LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
           ,AppointmentDate=@AppointmentDate
           ,PaidFees=@PaidFees
           ,CreatedByUserID=@CreatedByUserID
           ,IsLocked=@IsLocked
           ,RetakeTestApplicationID=@RetakeTestApplicationID where TestAppointmentID=@TestAppointmentID;
           ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", (decimal)PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@isLocked", isLocked);
            if (RetakeTestApplicationID == -1)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

            }
            try
            {
                connection.Open();
               RowEffect = command.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return RowEffect!=-1&&RowEffect!=0;
        }
        public static bool isTestAppintmentLocked(int TestAppointmentID)
        {
            bool isLocked = false;
            string Query = @"
                             select Found=1 from TestAppointments where TestAppointmentID=@TestAppointmentID and IsLocked=1;
           ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                object reader = command.ExecuteScalar();
                if (reader != null)
                {
                    isLocked = true;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (isLocked);
        }
        public static int GetTestID(int TestAppointmentID)
        {
            int ID = -1;
            string Query = @"
                           select TestID from Tests where TestAppointmentID=@TestAppointmentID;
                            ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
           
            try
            {
                connection.Open();
                object reader = command.ExecuteScalar();
                if (reader != null && int.TryParse(reader.ToString(), out int NewID))
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
    }
}
