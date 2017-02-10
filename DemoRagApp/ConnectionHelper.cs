using System;
namespace databaseconnection
{
    public class ConnectionHelper
    {
        public ConnectionHelper()
        {
        }

        public static SqlConnection OpenSqlConnection()
        {
            String connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                Console.WriteLine("State: {0}", connection.state);
                Console.WriteLine("ConnectionString:  {0}", connection.ConnectionString);
            }
            return conn;

        }
        private static String GetConnectionString()
        {
            return "Data Source=throwawaydb.cacbbedpgsnb.us-east-1.rds.amazonaws.com,1433;Initial Catalog=Bears;Persist Security Info=True;User ID=master;Password=lolmaster";
        }
    }
}
