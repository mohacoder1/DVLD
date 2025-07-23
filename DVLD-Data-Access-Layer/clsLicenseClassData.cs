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
    public class clsLicenseClassData
    {
        //  ,[ClassName]
        //,[ClassDescription]
        //,[MinimumAllowedAge]
        //,[DefaultValidityLength]
        //,[ClassFees]
        public static DataTable getAll()
        {
            DataTable dt = new DataTable();
            string Query = @"
             select ClassName from LicenseClasses ;  
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
        public static DataTable getAllLicensesClassesInfo()
        {
            DataTable dt = new DataTable();
            string Query = @"
             select * from LicenseClasses ;  
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
        public static bool GetLicenseClassesByID(int LicenseClassID, ref string ClassName, ref string ClassDescription,
            ref int MinimumAllowedAge, ref int DefaultValidityLength, ref double ClassFees)
        {
            bool isFound = false;

            string Query = @"
                            select * from LicenseClasses where LicenseClassID=@LicenseClassID ;  
                            ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (int)reader["ClassMinimumAllowedAgeName"];
                    DefaultValidityLength = (int)reader["DefaultValidityLength"];
                    ClassFees = Convert.ToDouble(reader["ClassName"]);

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
       

    }
}
