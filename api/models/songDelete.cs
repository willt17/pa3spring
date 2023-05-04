using System.Runtime.InteropServices;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace api.models
{
    public class songDelete
    {
        public static void DeleteSong(string id, song deleteSong)
        {
            DBconnection connection = new DBconnection();
            bool isOpen = connection.OpenCon();
            if(isOpen)
            {
                deleteSong.isDeleted = "true";
                MySqlConnection? con = connection.GetCon();
                string statement = @"UPDATE songs SET isDeleted=@isDeleted WHERE songID=@songId";
                using var cmd = new MySqlCommand(statement, con);
                cmd.Parameters.AddWithValue("@isDeleted", deleteSong.isDeleted);
                cmd.Parameters.AddWithValue("@songID", deleteSong.songId);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            else
            {
                System.Console.WriteLine("Error with database connection.");
            }
            connection.CloseCon();
        }
    }
}