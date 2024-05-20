namespace GameStore.Models.API
{
    public class Game
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }        
        public DateTime ReleaseDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
