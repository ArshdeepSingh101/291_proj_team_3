using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace _291_proj
{
    public class DataAccess
    {
        private static readonly string connectionString = @"Server=100.102.207.92;Database=DB291;User ID=sa;Password=Levitron14;TrustServerCertificate=True;Encrypt=False;";
        
        /// <summary>
        /// Returns a display-safe version of the connection string (password masked)
        /// </summary>
        public static string GetConnectionStringForDisplay()
        {
            // Return a version with the password masked
            return connectionString.Replace("Password=Levitron14", "Password=********");
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    return dt;
                }
            }
        }

        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
