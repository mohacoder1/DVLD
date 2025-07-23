using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    static public class clsApplicationTypesData
    {
        static public DataTable All()
        {
            DataTable dt = new DataTable();
            string Query = @"Select * from ApplicationTypes";
            SqlConnection connection=new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query,connection);
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

                throw;
            }
            finally
            { 
                connection.Close(); 
            }
            return dt;
        }
        static public bool UpdateApplicationFees(int ApplicationTypeID, string ApplicationTypeTitle, double ApplicationFees)
        {
            int RowEffect = -1;
            string Query = @"
Update ApplicationTypes set
ApplicationTypeTitle =@ApplicationTypeTitle,
ApplicationFees=@ApplicationFees
where ApplicationTypeID=@ApplicationTypeID
";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("ApplicationTypeTitle", ApplicationTypeTitle);
            cmd.Parameters.AddWithValue("ApplicationFees", (decimal)ApplicationFees);
            try
            {
                connection.Open();
                RowEffect = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally 
            { connection.Close(); }
            return RowEffect!=-1;
        }
        static public bool FindApplicationType(int ApplicationTypeID, ref string ApplicationTypeTitle, ref double ApplicationFees)
        {
            bool isFound = false;

            string Query = "select * from ApplicationTypes where ApplicationTypeID=@ApplicationTypeID";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);
           
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationFees = Convert.ToDouble( reader["ApplicationFees"]);

                }
            }
            catch (Exception ex)
            {
              Console.WriteLine(  ex.Message);
            }
            finally
            { connection.Close(); }
            return isFound; 
        }
        static public bool FindApplicationTypeByTitle(ref int ApplicationTypeID,  string ApplicationTypeTitle, ref double ApplicationFees)
        {
            bool isFound = false;

            string Query = "select * from ApplicationTypes where ApplicationTypeTitle=@ApplicationTypeTitle";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("ApplicationTypeTitle", ApplicationTypeTitle);
           
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationFees = Convert.ToDouble( reader["ApplicationFees"]);

                }
            }
            catch (Exception ex)
            {
              Console.WriteLine(  ex.Message);
            }
            finally
            { connection.Close(); }
            return isFound; 
        }

    }
}
