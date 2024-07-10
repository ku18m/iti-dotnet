using Microsoft.Data.SqlClient;
using System.Data;

namespace Instructors.DataAccess
{
    public class DBContext
    {
        private static string connectionString = "Server=DESKTOP-C2CGBOT\\SQLEXPRESS;Database=ITI;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True";
        private static SqlConnection con = new(connectionString);

        public static DataTable ExecuteQueryCommand(string command)
        {
            SqlCommand cmd = new(command, con);
            SqlDataAdapter adapter = new(cmd);
            DataTable dt = new();

            adapter.Fill(dt);

            return dt;
        }

        public static int ExecuteNonQueryCommand(string command)
        {
            SqlCommand cmd = new(command, con);
            int rowsAffected = 0;

            try
            {
                con.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                con.Close();
            }

            return rowsAffected;
        }
    }
}
