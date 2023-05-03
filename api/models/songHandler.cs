namespace api.models
{
    public class songHandler
    {
        public static List<song> allSongs = new List<song>();

        public List<song> GetAllSongs()
        {
            song testSong = new song(){songId = "1", songTitle = "Daisy's Song", artistName = "Daisy", isFavorited = false,isDeleted = false};
            song test2 = new song(){songId = "2", songTitle = "Joey's Song", artistName = "Joey", isFavorited = false, isDeleted = false};
            allSongs.Add(testSong);
            allSongs.Add(test2);
            return allSongs;
        }
        public void AddSong(song newSong)
        {
            allSongs.Add(newSong);
        }
        public void EditSong(string id,song editSong)
        {
            int indexNumber = allSongs.FindIndex(s => s.songId == id);
            allSongs.RemoveAt(indexNumber);
            allSongs.Add(editSong);
        }
        public void DeleteSong(string id)
        {
            int indexNumber = allSongs.FindIndex(s => s.songId == id);
            allSongs.RemoveAt(indexNumber);
        }
    }

}