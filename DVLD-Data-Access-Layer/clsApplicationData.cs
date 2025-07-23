using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public class clsApplicationData
    {
      public  static bool GetApplicationByID(int ID,ref int PersonID,ref DateTime ApplicationDate ,ref int ApplicationTypeID,
          ref short ApplicationStatus,ref DateTime LastStatusDate,ref double PayFees, ref int UserID)
        {
            bool isFound=false; 
            SqlConnection connection=new SqlConnection(clsDataAccessSettings.Connection);
            string Query = @"
                            SELECT ApplicationID
                           ,ApplicantPersonID
                           ,ApplicationDate
                           ,ApplicationTypeID
                           ,ApplicationStatus
                           ,LastStatusDate
                           ,PaidFees
                           ,CreatedByUserID
                            FROM Applications where ApplicationID=@ID;";
            SqlCommand command=new SqlCommand(Query, connection);
    
            command.Parameters.AddWithValue("ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    PersonID=(int)reader["ApplicantPersonID"];
                    ApplicationTypeID=(int)reader["ApplicationTypeID"];
                    UserID=(int)reader["CreatedByUserID"];
                    ApplicationStatus = (byte)reader["ApplicationStatus"];
                    ApplicationDate=(DateTime)reader["ApplicationDate"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PayFees = Convert.ToDouble(reader["PaidFees"]);
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
        public static int AddNewApplication( int ApplicantPersonID,  DateTime ApplicationDate,  int ApplicationTypeID,
               short ApplicationStatus,  DateTime LastStatusDate,  double PaidFees,  int CreatedByUserID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = @"
                       
           INSERT INTO Applications
           (ApplicantPersonID
           ,ApplicationDate
           ,ApplicationTypeID
           ,ApplicationStatus
           ,LastStatusDate
           ,PaidFees
           ,CreatedByUserID)

             VALUES
           (@ApplicantPersonID
           ,@ApplicationDate
           ,@ApplicationTypeID
           ,@ApplicationStatus
           ,@LastStatusDate
           ,@PaidFees
           ,@CreatedByUserID); select SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", (decimal)PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();
                object reader = command.ExecuteScalar();
                if (reader !=null&&int.TryParse(reader.ToString(),out int NewID))
                {
                    ID= NewID;  
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
        public static DataTable GetAll()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = @"Select * from Applications;";
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
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static bool UpdateApplication(int ID, int PersonID, DateTime ApplicationDate, int ApplicationTypeID,
           short ApplicationStatus, DateTime LastStatusDate, double PaidFees, int UserID)
        {
            int RowEffect = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = @"UPDATE Applications
                        SET ApplicantPersonID = @PersonID,
                            ApplicationDate = @ApplicationDate,
                            ApplicationTypeID = @ApplicationTypeID, 
                           ApplicationStatus = @ApplicationStatus,
                           LastStatusDate = @LastStatusDate, 
                           PaidFees = @PaidFees,
                           CreatedByUserID = @UserID
                           WHERE ApplicationID=@ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("ID", ID);
            command.Parameters.AddWithValue("PersonID", PersonID);
            command.Parameters.AddWithValue("ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("PaidFees", (decimal)PaidFees);
            command.Parameters.AddWithValue("UserID", UserID);
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
            return RowEffect != -1;

        }
        public static bool DeleteApplication(int ApplicationID)
        {
            int RowEffect = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = @"delete from Applications
                           WHERE ApplicationID=@ApplicationID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("ApplicationID", ApplicationID);
            
            try
            {
                connection.Open();
                RowEffect = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
            return RowEffect != -1;

        }
        public static bool isAppExists(int ID)
        {
            bool Exists=false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = @"select 2 from Applications
                           WHERE ApplicationID=@ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("ID", ID);

            try
            {
                connection.Open();
                object reader= command.ExecuteScalar();
                if (reader!=null)
                {
                    Exists = true;

                }
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
            return Exists;

        }

        public static bool DoesPersonHasActiveApplication(int PersonID,int ApplicationTypeID)
        {
            return GetActiveAppID(PersonID,ApplicationTypeID)!=-1;

        }
        public static int GetActiveAppID(int PersonID , int ApplicationTypeID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = @"select ApplicationID from Applications
                           WHERE PersonID=@PersonID And ApplicationTypeID=@ApplicationTypeID And ApplicationStatus=1;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("PersonID", PersonID);
            command.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                object reader = command.ExecuteScalar();
                if (reader != null&& int.TryParse(reader.ToString(),out int ActiveAppID))
                {
                    ID = ActiveAppID;

                }
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
            return ID;

        }
        public static int GetActiveAppIDForLicenses(int PersonID, int ApplicationTypeID,int LicenseClassID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = @"select a.ApplicationID from Applications a inner join LocalDrivingLicenseApplications l 
                             on a.ApplicationID=l.ApplicationID
                             where a.ApplicantPersonID=@PersonID and a.ApplicationTypeID=@ApplicationTypeID 
                             and a.ApplicationStatus=1 and l.LicenseClassID=LicenseClassID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("PersonID", PersonID);
            command.Parameters.AddWithValue("LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                object reader = command.ExecuteScalar();
                if (reader != null && int.TryParse(reader.ToString(), out int ActiveAppID))
                {
                    ID = ActiveAppID;

                }
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
            return ID;

        }
        public static bool UpdateStatus(int ID, short NewStatus)
        {
            int RowEffected = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            string Query = @"update Applications  set ApplicationStatus=@NewStatus
                            ,LastStatusDate=@LastStatusDate where ApplicationID=@ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("ID", ID);
            command.Parameters.AddWithValue("NewStatus",(byte)NewStatus);
            command.Parameters.AddWithValue("LastStatusDate", DateTime.Now);

            try
            {
                connection.Open();
                RowEffected = command.ExecuteNonQuery();
                
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
            return RowEffected!=-1;

        }

    }
}
