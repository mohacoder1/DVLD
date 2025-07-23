using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;

namespace DVLD_Data_Access_Layer
{
    public class clsLicenseData
    {
        public static DataTable GetAllLicensseInfo()
        {
            DataTable dt = new DataTable();
            string Query = @"
                select * from Licenses ;  
";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
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
        public static DataTable GetDriversLicensseInfo(int DriverID )
        {
            DataTable dt = new DataTable();
            string Query = @"
                           SELECT l.LicenseID,l.ApplicationID,LicenseClasses.ClassName,  l.IssueDate, 
                            l.ExpirationDate,l.CreatedByUserID,l.IsActive FROM  Licenses l INNER JOIN
                            LicenseClasses on l.LicenseClass=LicenseClasses.LicenseClassID where DriverID=@DriverID 
                            order by ExpirationDate desc 
 ;  
";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("DriverID", DriverID);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
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

        public static int GetActiveLicenseByPersonID(int PersonID, int LicenseClassID)
        {
            int LicenseID = -1;

            string Query = @"
                            select LicenseID from Licenses inner join 
                             Drivers on Drivers.DriverID=Licenses.DriverID where
                             Drivers.PersonID= @PersonID and Licenses.LicenseClass=@LicenseClassID and IsActive=1
  
                            ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("LicenseClassID", LicenseClassID);
            cmd.Parameters.AddWithValue("PersonID", PersonID);
            try
            {
                connection.Open();
                object reader = cmd.ExecuteScalar();
                if (reader != null && int.TryParse(reader.ToString(), out int ID))
                {
                    LicenseID = ID;
                }
                   
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
           

            return LicenseID;
        }
        public static bool GetLicenseInfoByID(int LicenseID, ref int applicationID, ref int driverID, ref int licenseClassID, ref DateTime issueDate,
           ref DateTime expirationDate, ref string notes, ref double paidFees, ref bool isActive, ref short issueReason, ref int createdByUserID)
        {
            bool isFound = false;

            string Query = @"
                            select * from Licenses where LicenseID=@LicenseID ;  
                            ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("LicenseID", LicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    applicationID = (int)reader["ApplicationID"];
                    driverID = (int)reader["DriverID"];
                    licenseClassID = (int)reader["LicenseClass"];
                    createdByUserID = (int)reader["CreatedByUserID"];
                    expirationDate = (DateTime)reader["ExpirationDate"];
                    issueDate = (DateTime)reader["IssueDate"];
                    if (reader["Notes"]!=DBNull.Value)
                    {
                        notes = (string)reader["Notes"];
                    }
                    issueReason = (byte)reader["IssueReason"];
                    paidFees = Convert.ToDouble(reader["PaidFees"]);
                    isActive = (bool)reader["IsActive"];

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
        public static bool GetLicenseInfoByDriverID(ref int LicenseID, ref int applicationID,  int DriverID, ref int licenseClassID, ref DateTime issueDate,
                  ref DateTime expirationDate, ref string notes, ref double paidFees, ref bool isActive, ref short issueReason, ref int createdByUserID)
        {
            bool isFound = false;

            string Query = @"
                            select * from Licenses where DriverID=@DriverID ;  
                            ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("DriverID", DriverID);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    applicationID = (int)reader["ApplicationID"];
                    LicenseID = (int)reader["LicenseID"];
                    licenseClassID = (int)reader["LicenseClass"];
                    createdByUserID = (int)reader["CreatedByUserID"];
                    expirationDate = (DateTime)reader["ExpirationDate"];
                    issueDate = (DateTime)reader["IssueDate"];
                    if (reader["Notes"]!=DBNull.Value)
                    {
                        notes = (string)reader["Notes"];
                    }
                    
                    issueReason = (byte)reader["IssueReason"];
                    paidFees = Convert.ToDouble(reader["PaidFees"]);
                    isActive = (bool)reader["IsActive"];

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
      
        public static bool Update( int LicenseID,  int ApplicationID, int DriverID, int LicenseClassID, 
                  DateTime ExpirationDate,  string Notes,  double PaidFees,  bool IsActive,  short IssueReason, int CreatedByUserID)
        {
            int RowEffect = -1;

            string Query = @"
                            UPDATE Licenses SET
                            ApplicationID = @ApplicationID
                           ,DriverID = @DriverID
                           ,LicenseClass = @LicenseClassID
                           
                      ,ExpirationDate = @ExpirationDate
      ,Notes= @Notes
      ,PaidFees = @PaidFees
      ,IsActive = @IsActive
      ,IssueReason = @IssueReason
      ,CreatedByUserID = @CreatedByUserID
 WHERE LicenseID=@LicenseID
                            ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("LicenseID", LicenseID);
            cmd.Parameters.AddWithValue("LicenseClass", LicenseClassID);
            cmd.Parameters.AddWithValue("DriverID", DriverID);
            cmd.Parameters.AddWithValue("ExpirationDate", ExpirationDate);
            if (!string.IsNullOrEmpty(Notes))
            {
                cmd.Parameters.AddWithValue("Notes", Notes);
            }
            else
                cmd.Parameters.AddWithValue("Notes", DBNull.Value);

            cmd.Parameters.AddWithValue("PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("IsActive", IsActive);
            cmd.Parameters.AddWithValue("IssueReason", IssueReason);
            cmd.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();
                RowEffect = cmd.ExecuteNonQuery();
                
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
        public static bool Delete(int LicenseID)
        {
            int RowEffect = -1;

            string Query = @"
                            Delete from Licenses WHERE LicenseID=@LicenseID
                            ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
         
            cmd.Parameters.AddWithValue("LicenseID", LicenseID);
           
            try
            {
                connection.Open();
                RowEffect = cmd.ExecuteNonQuery();

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
        public static int Add( int ApplicationID, int DriverID, int LicenseClassID,
                DateTime ExpirationDate, string Notes, double PaidFees, bool IsActive, short IssueReason, int CreatedByUserID)
        {
            
            int LicenseID = -1;
            string Query = @"
                            insert into Licenses Values(
                            @ApplicationID
                           ,@DriverID
                           ,@LicenseClass
                           ,@IssueDate
                           ,@ExpirationDate 
                                     ,@Notes
                                    ,@PaidFees 
                                    ,@IsActive
                                    ,@IssueReason
                                    ,@CreatedByUserID);select SCOPE_IDENTITY();
                            ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("LicenseClass", LicenseClassID);
            cmd.Parameters.AddWithValue("DriverID", DriverID);
            cmd.Parameters.AddWithValue("IssueDate", DateTime.Now);
            cmd.Parameters.AddWithValue("ExpirationDate", ExpirationDate);
            if (!string.IsNullOrEmpty(Notes))
            {
                cmd.Parameters.AddWithValue("Notes", Notes);
            }
            else
                cmd.Parameters.AddWithValue("Notes", DBNull.Value);

            cmd.Parameters.AddWithValue("PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("IsActive", IsActive);
            cmd.Parameters.AddWithValue("IssueReason", IssueReason);
            cmd.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();
                object Result = cmd.ExecuteScalar();
                if (Result != null&&int.TryParse(Result.ToString(),out int NewID))
                {
                    LicenseID = NewID;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return LicenseID;

        }
        public static bool IsLicenseExists( int LicenseID)
        {
            bool isFound = false;

            string Query = @"
                            select Found=1 from Licenses where LicenseID=@LicenseID ;  
                            ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("LicenseID", LicenseID);
            try
            {
                connection.Open();
                object reader = cmd.ExecuteScalar();
                if (reader!=null)
                {
                    isFound = true;

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
        public static bool IsLicenseExistsByDriverID(int DriverID)
        {
            bool isFound = false;

            string Query = @"
                            select Found=1 from Licenses where DriverID=@DriverID ;  
                            ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("DriverID", DriverID);
            try
            {
                connection.Open();
                object reader = cmd.ExecuteScalar();
                if (reader != null)
                {
                    isFound = true;

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

        public static bool DeactiveLicense(int LicenseID)
        {
            int RowEffect = -1;

            string Query = @"
                            UPDATE Licenses SET
                            IsActive = 0 WHERE LicenseID=@LicenseID
                            ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
      
            cmd.Parameters.AddWithValue("LicenseID", LicenseID);
         
            try
            {
                connection.Open();
                RowEffect = cmd.ExecuteNonQuery();

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
