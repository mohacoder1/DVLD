using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public class clsDetainedLicensesData
    {
        /*
       SELECT TOP (1000) [DetainID]
      ,[LicenseID]
      ,[DetainDate]
      ,[FineFees]
      ,[CreatedByUserID]
      ,[IsReleased]
      ,[ReleaseDate]
      ,[ReleasedByUserID]
      ,[ReleaseApplicationID]
  FROM [DVLD].[dbo].[DetainedLicenses]
         */
        public static bool GetDetainedLicenseByID(int DetainID, ref int LicenseID, ref DateTime DetainDate, ref double FineFees, ref int CreatedByUserID
            ,ref bool IsReleased, ref DateTime ReleaseDate , ref  int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound=false;
            string Query = "Select * from DetainedLicenses where DetainID=@DetainID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("DetainID", DetainID);

            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    LicenseID = (int)Reader["LicenseID"];
                    DetainDate = (DateTime)Reader["DetainDate"];
                    FineFees = Convert.ToDouble(Reader["FineFees"]);
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsReleased = (bool)Reader["IsReleased"];

                    if (Reader["ReleaseDate"] != null)
                        ReleaseDate = (DateTime)Reader["ReleaseDate"];

                    else
                        ReleaseDate = DateTime.Now.AddYears(-23);

                    if (Reader["ReleasedByUserID"] != null)
                        ReleasedByUserID = (int)Reader["ReleasedByUserID"];

                    else
                        ReleasedByUserID = -1;

                    if (Reader["ReleaseApplicationID"] != null)
                        ReleaseApplicationID = (int)Reader["ReleaseApplicationID"];

                    else
                        ReleasedByUserID = -1;


                };

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

        public static bool GetDetainedLicenseByLicenseID(ref int DetainID, int LicenseID, ref DateTime DetainDate, ref double FineFees, ref int CreatedByUserID
          , ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;
            string Query = "Select * from DetainedLicenses where LicenseID=@LicenseID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    DetainID = (int)Reader["DetainID"];
                    DetainDate = (DateTime)Reader["DetainDate"];
                    FineFees = Convert.ToDouble(Reader["FineFees"]);
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsReleased = (bool)Reader["IsReleased"];

                    if (Reader["ReleaseDate"] != null)
                        ReleaseDate = (DateTime)Reader["ReleaseDate"];

                    else
                        ReleaseDate = DateTime.Now.AddYears(-23);

                    if (Reader["ReleasedByUserID"] != null)
                        ReleasedByUserID = (int)Reader["ReleasedByUserID"];

                    else
                        ReleasedByUserID = -1;

                    if (Reader["ReleaseApplicationID"] != null)
                        ReleaseApplicationID = (int)Reader["ReleaseApplicationID"];

                    else
                        ReleasedByUserID = -1;


                };

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
       
        public static bool GetDetainedLicenseByReleaseID(ref int DetainID, ref int LicenseID, ref DateTime DetainDate, ref double FineFees, ref int CreatedByUserID
              , ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, int ReleaseApplicationID)
        {
            bool isFound = false;
            string Query = "Select * from DetainedLicenses where ReleaseApplicationID=@ReleaseApplicationID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("ReleaseApplicationID", ReleaseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    DetainID = (int)Reader["DetainID"];
                    DetainDate = (DateTime)Reader["DetainDate"];
                    FineFees = Convert.ToDouble(Reader["FineFees"]);
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsReleased = (bool)Reader["IsReleased"];
                    ReleaseDate = (DateTime)Reader["ReleaseDate"];
                    ReleasedByUserID = (int)Reader["ReleasedByUserID"];
                    LicenseID = (int)Reader["LicenseID"];

                };

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
        public static DataTable GetDetainedLicenses()
        {
            DataTable dtLicense = new DataTable();
            string Query = "Select * from  DetainLicenses_View ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    dtLicense.Load(Reader);
                    

                };

            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return dtLicense;
        }

        public static bool UpdateDetainedLicense( int DetainID,  int LicenseID,  DateTime DetainDate,  double FineFees,  int CreatedByUserID
             ,  bool IsReleased,  DateTime ReleaseDate,  int ReleasedByUserID, int ReleaseApplicationID)
        {
            int rowEffect = -1;
            string Query = @"Update DetainedLicenses set
                                       CreatedByUserID=@CreatedByUserID,
                                       LicenseID=@LicenseID,
                                       DetainDate=@DetainDate,
                                       FineFees=@FineFees,
                                       IsReleased=@IsReleased,
                                       ReleaseDate=@ReleaseDate,
                                       ReleasedByUserID=@ReleasedByUserID,
                                       ReleaseApplicationID=@ReleaseApplicationID where DetainID=@DetainID
";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("DetainID", DetainID);
            cmd.Parameters.AddWithValue("LicenseID", LicenseID);
            cmd.Parameters.AddWithValue("DetainDate", DetainDate);
            cmd.Parameters.AddWithValue("FineFees", FineFees);
            cmd.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);
            
            cmd.Parameters.AddWithValue("IsReleased", IsReleased);
            cmd.Parameters.AddWithValue("ReleaseDate", ReleaseDate);
            cmd.Parameters.AddWithValue("ReleasedByUserID", ReleasedByUserID);
            cmd.Parameters.AddWithValue("ReleaseApplicationID", ReleaseApplicationID);

            try
            {
                connection.Open();
                rowEffect = cmd.ExecuteNonQuery();
               

            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return rowEffect>0;
        }
        public static bool DeleteDetainedLicense(int DetainID)
        {
            int rowEffect = -1;
            string Query = "Delete * from DetainedLicenses where DetainID=@DetainID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("DetainID", DetainID);
            

            try
            {
                connection.Open();
                rowEffect = cmd.ExecuteNonQuery();


            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return rowEffect > 0;
        }
        public static bool DeleteDetainedLicenseByLicenseID(int LicenseID)
        {
            int rowEffect = -1;
            string Query = "Delete * from DetainedLicenses where LicenseID=@LicenseID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("LicenseID", LicenseID);
            

            try
            {
                connection.Open();
                rowEffect = cmd.ExecuteNonQuery();


            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return rowEffect > 0;
        }
        public static int AddNewDetainedLicense(int LicenseID, double FineFees, int CreatedByUserID)
        {
            int ID = -1;
            string Query = @"INSERT INTO dbo.DetainedLicenses
                               (LicenseID,
                               DetainDate,
                               FineFees,
                               CreatedByUserID,
                               IsReleased
                               )
                            VALUES
                               (@LicenseID,
                               @DetainDate, 
                               @FineFees, 
                               @CreatedByUserID,
                               0
                             );
                            
                            SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("LicenseID", LicenseID);
            cmd.Parameters.AddWithValue("DetainDate", DateTime.Now);
            cmd.Parameters.AddWithValue("FineFees", FineFees);
            cmd.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);


            try
            {
                connection.Open();
                object Result = cmd.ExecuteScalar();
                if (Result!=null&&int.TryParse(Result.ToString(),out int newID))
                {
                    ID = newID;   
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return ID ;
        }
        public static bool isLicenseDetained(int LicenseID)
        {
            int ID = -1;
            string Query = @"select DetainID from DetainedLicenses where LicenseID=@LicenseID and IsReleased=0";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("LicenseID", LicenseID);


            try
            {
                connection.Open();
                object Result = cmd.ExecuteScalar();

                if (Result!=null&&int.TryParse(Result.ToString(), out int NewID))
                {
                    ID= NewID;
                }


            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return ID != -1;
        }
        public static bool ReleaseDetainedLicense(int DetainID , int ReleasedByUserID, int ReleaseApplicationID)
        {
            int RowEffect = -1;
            string Query = @" Update DetainedLicenses set
IsReleased=1,
ReleasedByUserID=@ReleasedByUserID,
ReleaseApplicationID=@ReleaseApplicationID,
ReleaseDate=@ReleaseDate where DetainID=@DetainID;
                                   ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("DetainID", DetainID);
            cmd.Parameters.AddWithValue("ReleasedByUserID", ReleasedByUserID);
            cmd.Parameters.AddWithValue("ReleaseApplicationID", ReleaseApplicationID);
            cmd.Parameters.AddWithValue("ReleaseDate", DateTime.Now);


            try
            {
                connection.Open();
                 RowEffect = cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return RowEffect > 0;
        }


    }
}
