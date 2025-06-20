using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GroceryWorld.Models
{
    public class Functions
    {
        private SqlConnection Con;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string ConnString;

        public Functions()
        {
            // Get connection string from web.config
            ConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            Con = new SqlConnection(ConnString);
            cmd = new SqlCommand();
            cmd.Connection = Con;
        }

        // Method to get data from the database
        public DataTable getData(string Query)
        {
            try
            {
                dt = new DataTable();
                using (sda = new SqlDataAdapter(Query, ConnString))
                {
                    sda.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                // Log or rethrow the exception
                throw new Exception("Error fetching data: " + ex.Message);
            }
        }

        // Method to execute commands that modify data (INSERT, UPDATE, DELETE)
        /*  public int setData(string query, params SqlParameter[] sqlParameters)
          {
              int rowsAffected = 0;

              try
              {
                  using (SqlConnection con = new SqlConnection(ConnString))
                  {
                      using (SqlCommand cmd = new SqlCommand(query, con))
                      {
                          if (sqlParameters != null)
                          {
                              cmd.Parameters.AddRange(sqlParameters);
                          }
                          con.Open();
                          rowsAffected = cmd.ExecuteNonQuery();
                      }
                  }
              }
              catch (Exception ex)
              {
                  // Log or rethrow the exception
                  throw new Exception("Error executing command: " + ex.Message);
              }

              return rowsAffected;
          }
        */

        public int setData(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection("your_connection_string"))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // Method to get the SQL connection
        public SqlConnection GetConnection()
        {
            return Con;
        }
    }
}