using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public static class clsTestTypesData
    {
        public static bool GetTestTypes(int ID , ref string TestTypeTitle ,ref string Desc,ref double Fees)
        {
            bool isFound = false;

            string Query = "Select * from TestTypes where TestTypeID=@ID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    Desc=(string)reader["TestTypeDescription"];
                    Fees=Convert.ToDouble(reader["TestTypeFees"]);

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
        static public DataTable All()
        {
            DataTable dt = new DataTable();
            string Query = @"Select * from TestTypes";
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

                throw;
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        static public bool UpdateTestFees(int ID,double Fees)
        {
            int RowEffect = -1;
            string Query = @"Update TestTypes set
                             TestTypeFees=@Fees
                            where TestTypeID=@ID";



            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("ID", ID);
            cmd.Parameters.AddWithValue("Fees", (decimal)Fees);

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
    }
}
