using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    static public  class clsCurrentUserData
    {
      public  static bool UpdateCurrentUser( string Username,   string Password )
        {
            int RowEffect = -1;

            string Query = "Update CurrentUser set Username=@Username  , Password=@Password ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand command=new SqlCommand(Query, connection);
            if(string.IsNullOrEmpty( Username))
            {
                command.Parameters.AddWithValue("Username", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("Username", Username);

            }

            if (string.IsNullOrEmpty(Password))
            {
                command.Parameters.AddWithValue("Password", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("Password", Password);

            }
       

            try
            {
                connection.Open();
                RowEffect=command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }
            return RowEffect!=-1;
        }
        public static bool GetCurrentUser(ref string Username, ref string Password )
        {
            

            string Query = "Select * from CurrentUser";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.Connection);
            SqlCommand command = new SqlCommand(Query, connection);
            
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                   
                    if (Reader["Username"] != DBNull.Value)
                    {
                        Username = (string)Reader["Username"];
                    }
                   else Username = null;

                    if (Reader["Password"] != DBNull.Value)
                    {
                        Password = (string)Reader["Password"];
                    }
                   else Password = null;

                   
                   
                }
            }
            catch (Exception)
            { }
            finally { connection.Close(); }
            return Username!=null&&Password!=null;
        }
    }
}
