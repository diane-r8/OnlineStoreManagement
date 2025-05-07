using MySql.Data.MySqlClient;

namespace OnlineStoreManagement
{
    public class DBConnection
    {
        private static string connectionString = "server=localhost;user=root;password=;database=onlinestore;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
