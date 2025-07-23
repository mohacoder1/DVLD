using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public class clsLocalLicenseApplicationData
    {
        public static bool GetLocalApplicationByApplicationID(ref int LocalID, int AppID, ref int LicenseClassID)
        {
            bool isFound=false;
            string Query = @"Select * from LocalDrivingLicenseApplications where ApplicationID=@AppID;";
            SqlConnection connection=new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand command=new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("AppID", AppID);
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    LocalID = (int)Reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)Reader["LicenseClassID"];
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static bool GetLocalApplicationByID(int LocalID,ref int AppID, ref int LicenseClassID)
        {
            bool isFound=false;
            string Query = @"Select * from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID=@LocalID;";
            SqlConnection connection=new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand command=new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("LocalID", LocalID);
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    AppID = (int)Reader["ApplicationID"];
                    LicenseClassID = (int)Reader["LicenseClassID"];
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static DataTable GetAll()
        {
            DataTable dataTable= new DataTable();   
            string Query = @"Select * from LocalDrivingLicenseApplications_View;";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                connection.Open ();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    dataTable.Load(sqlDataReader);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }

            return dataTable;
        }
        public static int AddNewApplications( int ApplicationID,  int LicenseClassID)
        {
            int ID=-1;
            string Query = @"
           INSERT INTO [dbo].[LocalDrivingLicenseApplications]
            ([ApplicationID]
           ,[LicenseClassID])
             VALUES
           (@ApplicationID, 
           @LicenseClassID)
		   ;select SCOPE_IDENTITY()";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                object Reader = command.ExecuteScalar();
                if (Reader!=null&&int.TryParse(Reader.ToString(),out int NewID))
                {
                    ID= NewID;
                }
            }
            catch (Exception sx)
            {

            }
            finally
            {
                connection.Close();
            }
            return ID;
        }
        public static bool UpdateApplicationinfo(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            int RowEffected = 0;
          
            string Query = @"UPDATE LocalDrivingLicenseApplications
                                SET ApplicationID = @ApplicationID,
                                   LicenseClassID = @LicenseClassID
                            WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID;";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                RowEffected = command.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return RowEffected!=0;
            
        }
        public static bool DeleteApplicationinfo(int ID )
        {
            int RowEffected = 0;

            string Query = @"Delete From LocalDrivingLicenseApplications 
                            Where LocalDrivingLicenseApplicationID=@ID ;";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("ID", ID);
            
            try
            {
                connection.Open();
                RowEffected = command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
            return RowEffected != 0;
        }

        public static int DoesPassTestType(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
          int Result = -1;

            string Query = @"
                                   
SELECT   top 1 TestResult
 FROM            LocalDrivingLicenseApplications  INNER JOIN
 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
  Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
						 where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID And TestAppointments.TestTypeID=TestTypeID And TestResult=1
						 order by TestAppointments.TestAppointmentID desc;";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object reader = command.ExecuteScalar();
                if (reader!=null&&int.TryParse (reader.ToString(),out int result))
                {
                    Result = result;
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
            return Result;
        }
        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool isAttend = false;

            string Query = @"SELECT   top 1 Found=1
                             FROM            LocalDrivingLicenseApplications  INNER JOIN
                         TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                         Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
						 where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID And TestAppointments.TestTypeID=@TestTypeID
						 order by TestAppointments.TestAppointmentID desc;";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object reader = command.ExecuteScalar();
                if (reader != null && int.TryParse(reader.ToString(), out int result))
                {
                    isAttend = (result == 1);
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
            return isAttend;
        }
        public static int TotalTrialPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
           int TotalTrials=0;

            string Query = @"SELECT   TotalTrialsPerTest=count(TestID)
                             FROM            LocalDrivingLicenseApplications  INNER JOIN
                         TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                         Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
						 where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID And TestAppointments.TestTypeID=@TestTypeID
						;";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object reader = command.ExecuteScalar();
                if (reader != null && int.TryParse(reader.ToString(), out int result))
                {
                    TotalTrials =result ;
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
            return TotalTrials;
        }
        public static bool isThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool Result = false;

            string Query = @"SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)  
                            AND(TestAppointments.TestTypeID = @TestTypeID) and isLocked=0
                            ORDER BY TestAppointments.TestAppointmentID desc;";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object reader = command.ExecuteScalar();
                if (reader != null )
                {
                    Result = true;
                }

            }
            catch (Exception ex)
            {

                
            }
            finally
            {
                connection.Close();
            }
            return Result;
        }
        public static bool isThereAnAppilcationExistsWithThisLicenseClassID(int PersonID, int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = @"
                         SELECT    1 FROM            LocalDrivingLicenseApplications INNER JOIN
                         LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID INNER JOIN
                         Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
						 where Applications.ApplicantPersonID=@PersonID and
                         LocalDrivingLicenseApplications.LicenseClassID=@LicenseClassID and Applications.ApplicationStatus != 2";
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("PersonID", PersonID);
            cmd.Parameters.AddWithValue("LicenseClassID", LicenseClassID);
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
