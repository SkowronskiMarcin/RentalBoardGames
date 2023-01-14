namespace RentalBoardGames.Entities
{
    /// <summary>
    /// Klasa dla encji do komentarzy
    /// </summary>
    public class BoardGameComment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        // * : 1 z BoardGame
        public BoardGame BoardGame { get; set; }
        public int BoardGameId { get; set; } //Klucz obcy

        // * : 1 z User

        public User User { get; set; }
        public int UserId { get; set; } //Klucz obcy
    }
}
