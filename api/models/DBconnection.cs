using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace api.models
{
    public class DBconnection
    {
        private MySqlConnection? connection;
        private string? server;
        private string? database;
        private string? port;
        private string? username;
        private string? password;

        public DBconnection()
        {
            Dbinit();
        }
        private void Dbinit()
        {
            server = "lin-20621-11811-mysql-primary.servers.linodedb.net";
            username = "linroot";
            database = "sys";
            port = "3306";
            password = "qDc63WYqUE3j!zZg";
            string cs = $@"server = {server};user={username};database={database};port={port};password={password};";
            connection = new MySqlConnection(cs);
        }
        public bool OpenCon()
        {
            try
            {
                connection?.Open();
                return true;
            }
            catch (MySqlException error)
            {
                if (error.Number == 0)
                {
                    System.Console.WriteLine(error.Message);
                    System.Console.WriteLine("Failed to Connect");
                }
                else if (error.Number == 1045)
                {
                    System.Console.WriteLine("Invalid User/Pass");
                }
            }
            return false;
        }
        public bool CloseCon()
        {
            try
            {
                connection?.Close();
                return true;
            }
            catch (MySqlException error)
            {
                System.Console.WriteLine(error.Message);
            }
            return false;
        }
        public MySqlConnection? GetCon()
        {
            return connection;
        }
    }
}