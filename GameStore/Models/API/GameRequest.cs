namespace GameStore.Models.API
{
    public class GameRequest
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}