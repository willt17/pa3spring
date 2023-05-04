using System.Runtime.InteropServices;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace api.models
{
    public class songPut
    {
        public static void SaveEdit(string id, song editSong)
        {
            DBconnection connection = new DBconnection();
            bool isOpen = connection.OpenCon();
            if(isOpen)
            {
                editSong.isFavorited = "true";
                MySqlConnection? con = connection.GetCon();
                string statement = @"UPDATE songs SET isFavorited=@isFavorited WHERE songID=@songId";
                using var cmd = new MySqlCommand(statement, con);
                cmd.Parameters.AddWithValue("@isFavorited", editSong.isFavorited);
                cmd.Parameters.AddWithValue("@songID", editSong.songId);
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