namespace RentalBoardGames.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Deadline { get; set; }

        // 1 : * z User
        public User User { get; set; }
        public int UserId { get; set; } //Klucz obcy

        // * : 1 z BoardGame
        public BoardGame BoardGame { get; set; }
        public int BoardGameId { get; set; } //Klucz obcy
    }
}
