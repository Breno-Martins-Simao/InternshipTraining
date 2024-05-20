namespace GameStore.Models.API
{
    public class Game
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
