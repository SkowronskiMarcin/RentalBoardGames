namespace RentalBoardGames.Entities
{
    /// <summary>
    /// Klasa dla encji do gier planszowych
    /// </summary>
    public class BoardGame
    {
        public int Id { get; set; }
        public string Name { get; set; }              
        public int Number_of_players  { get; set; }
        public bool? availability { get; set; }

        // 1 : * z BoardGameComment
        public List<BoardGameComment> Comments { get; set; } = new List<BoardGameComment>();
        // 1 : * z Transaction
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        //* : * z Tag
        public List<Tag> Tags { get; set; }
    }
}
