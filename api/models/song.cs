namespace api.models
{
    public class song
    {
        public string? songId { get; set; }
        public string? songTitle { get; set; }
        public string? artistName { get; set; }
        public string? isFavorited { get; set; }
        public string? isDeleted { get; set; }

        public string? dateAdded {get; set;}

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