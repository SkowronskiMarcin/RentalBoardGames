namespace RentalBoardGames.Entities
{
    public class BoardGame
    {
        public int Id { get; set; }
        public string Name { get; set; }              
        public int Number_of_players  { get; set; }
        public bool? availability { get; set; }

        // 1 : * z BoardGameComment
        public List<BoardGameComment> Comments { get; set; } = new List<BoardGameComment>();

        // 1 : * z User
        public User User { get; set; }
        public int UserId { get; set; } //Klucz obcyddd

        // 1 : * z Transaction
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        //* : * z Tag
        public List<Tag> Tags { get; set; }
    }
}
