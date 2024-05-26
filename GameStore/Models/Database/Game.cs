namespace GameStore.Models.Database
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
    }
}
