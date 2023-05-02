namespace api.models
{
    public class song
    {
        public int songId { get; set; }
        public string songTitle { get; set; }
        public string artistName { get; set; }
        public bool isFavorited { get; set; }
        public bool isDeleted { get; set; }
    }
}