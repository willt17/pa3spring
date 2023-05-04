using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace api.models
{
    public class songHandler
    {
        // public static List<song> allSongs = new List<song>();

        public  static List<song> GetAllSongs()
        {
            // song testSong = new song(){songId = "1", songTitle = "Daisy's Song", artistName = "Daisy", isFavorited = "false",isDeleted = "false", dateAdded = "01-01-01"};
            // song test2 = new song(){songId = "2", songTitle = "Joey's Song", artistName = "Joey", isFavorited = "false", isDeleted = "false", dateAdded = "02-02-02"};
            // allSongs.Add(testSong);
            // allSongs.Add(test2);
            List<song> allSongs = new List<song>();
            DBconnection connection = new DBconnection();
            bool isOpen = connection.OpenCon();
            if(isOpen)
            {
                MySqlConnection con = connection.GetCon();
                string statement = "SELECT * from songs";
                using var cmd = new MySqlCommand(statement, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    song tempSong = new song() {songId = reader.GetString(0), songTitle = reader.GetString(1), artistName = reader.GetString(2), dateAdded = reader.GetString(3), isDeleted = reader.GetString(4), isFavorited = reader.GetString(5)};
                    allSongs.Add(tempSong);
                }
                connection.CloseCon();
                return allSongs;
            }
            else
            {
                return new List<song>();
            }
        }
        // public void AddSong(song newSong)
        // {
        //     allSongs.Add(newSong);
        // }
        // public void EditSong(string id,song editSong)
        // {
        //     int indexNumber = allSongs.FindIndex(s => s.songId == id);
        //     allSongs.RemoveAt(indexNumber);
        //     allSongs.Add(editSong);
        // }
        // public void DeleteSong(string id)
        // {
        //     int indexNumber = allSongs.FindIndex(s => s.songId == id);
        //     allSongs[indexNumber].isDeleted = ("true");
        // }
    }

}