using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public class clsTestData
    {
       
        static public DataTable GetAllTests()
        {
            
            DataTable dtTests= new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = @" Select * from Tests;
                                ";
            SqlCommand command=new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dtTests.Load(reader);
                }

            }
            catch (Exception ex)
            {

            }
               finally { connection.Close(); }
            return dtTests;
        }
        static public bool GetTestByTestID(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool isFound=false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = @" Select * from Tests where TestID=@TestID;
                                ";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("TestID", TestID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                   isFound = true;
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    Notes = (string)reader["Notes"]??"No Notes !";
                    TestResult = (bool)reader["TestResult"];
                }

            }
            catch (Exception ex)
            {
               
            }
            finally { connection.Close(); }
            return isFound;
        }
        static public bool GetTestByTestAppointmentID(ref int TestID,  int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = @" Select * from Tests where TestAppointmentID=@TestAppointmentID;
                                ";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    TestID = (int)reader["TestID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    Notes = (string)reader["Notes"] ?? "No Notes !";
                    TestResult = (bool)reader["TestResult"];
                }

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return isFound;
        }
  /**/      static public bool GetLastTestByPersonAndTestTypeAndLicenseClass(int PersonID,int TestTypeID , int LicenseClassID, ref int TestID,  int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = @" SELECT   top 1     Tests.*, Applications.ApplicantPersonID
                   FROM            LocalDrivingLicenseApplications l INNER JOIN
                         Applications ON l.ApplicationID = Applications.ApplicationID INNER JOIN
                         TestAppointments ON l.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                         Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID 
						 where Applications.ApplicantPersonID=@PersonID and l.LicenseClassID=@LicenseClassID and TestAppointments.TestTypeID=@TestTypeID
						 order By  TestAppointmentID desc
";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("PersonID", PersonID);
            command.Parameters.AddWithValue("LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    TestID = (int)reader["TestID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    Notes = (string)reader["Notes"] ?? "No Notes !";
                    TestResult = (bool)reader["TestResult"];
                }

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return isFound;
        }

        static public int AddNewTest( int TestAppointmentID,  bool TestResult,  string Notes,  int CreatedByUserID)
        {
            int ID = -1;
          
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = @" 
            INSERT INTO Tests
           (TestAppointmentID,
           TestResult,
           Notes,
           CreatedByUserID)
     VALUES
           (@TestAppointmentID
           ,@TestResult
           ,@Notes,
           @CreatedByUserID);
		   
		   update TestAppointments set IsLocked=1 where TestAppointmentID=@TestAppointmentID
		   select SCOPE_IDENTITY();
                                ";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("TestResult", TestResult);
            if (string.IsNullOrEmpty(Notes))
            {
            command.Parameters.AddWithValue("Notes",  DBNull.Value);

            }
            else
            {
            command.Parameters.AddWithValue("Notes", Notes);

            }

            command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();
                object reader=command.ExecuteScalar();
                if (reader!=null&&int.TryParse(reader.ToString(),out int newID))

                {
                    ID = newID;

                }
            }
            catch(Exception ex) {
             
            }
            finally
            {
connection.Close();
            }
            return ID;
        }
        static public bool UpdateTest(int TestID,  int TestAppointmentID,  bool TestResult,  string Notes,  int CreatedByUserID)
        {
            int RowEffect = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = @" 
            Update  Tests set
           TestAppointmentID=@TestAppointmentID,
           TestResult=@TestResult,
           Notes=@Notes,
           CreatedByUserID =@CreatedByUserID where TestID=@TestID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("TestID", TestID);
            command.Parameters.AddWithValue("TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("TestResult", TestResult);
            if (string.IsNullOrEmpty(Notes))
            {
                command.Parameters.AddWithValue("Notes", DBNull.Value);

            }
            else
            {
                command.Parameters.AddWithValue("Notes", Notes);

            }

            command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);
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
            return RowEffect==-1;
        }
        static public int GetPassedTest(int LocalDrivingLicenseApplicationID)
        {
            int PassedTest = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = @"select COUNT (TestTypeID)
from Tests inner join TestAppointments
on TestAppointments.TestAppointmentID=Tests.TestAppointmentID 
where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID and TestResult=1";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                object reader = command.ExecuteScalar();
                if (reader!=null&&int.TryParse(reader.ToString(),out int result))
                {
                    PassedTest = result;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return PassedTest;
        }
   


    }
}
