namespace api.models
{
    public class song
    {
        public string? songId { get; set; }
        public string? songTitle { get; set; }
        public string? artistName { get; set; }
        public bool isFavorited { get; set; }
        public bool isDeleted { get; set; }

        public song()
        {
            songId = Guid.NewGuid().ToString();
        }
        public override string ToString()
        {
            return $"{songId} {songTitle} {artistName} {isFavorited} {isDeleted}";
        }
    }
}