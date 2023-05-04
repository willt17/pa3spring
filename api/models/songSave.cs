using MySql.Data.MySqlClient;

namespace api.models
{
    public class songSave
    {
        public static void AddSong(song newSong)
        {
            DBconnection connection = new DBconnection();
            bool isOpen = connection.OpenCon();
            if(isOpen)
            {
                MySqlConnection? con = connection.GetCon();
                string statement = @"INSERT INTO songs(songID, songTitle, artistName, dateAdded, isDeleted, isFavorited) VALUES(@songID, @songTitle, @artistName, @dateAdded, @isDeleted, @isFavorited)";
                using var cmd = new MySqlCommand(statement, con);
                cmd.Parameters.AddWithValue("@songID", newSong.songId);
                cmd.Parameters.AddWithValue("@songTitle", newSong.songTitle);
                cmd.Parameters.AddWithValue("@artistName", newSong.artistName);
                cmd.Parameters.AddWithValue("@dateAdded", newSong.dateAdded);
                cmd.Parameters.AddWithValue("@isDeleted", newSong.isDeleted);
                cmd.Parameters.AddWithValue("@isFavorited", newSong.isFavorited);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            else
            {
                System.Console.WriteLine("Error with database conncection.");
            }
            connection.CloseCon();
        }
    }
}