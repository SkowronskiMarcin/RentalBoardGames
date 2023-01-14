namespace RentalBoardGames.Entities
{
    /// <summary>
    /// Class entity for Board game table
    /// </summary>
    public class BoardGame
    {
        /// <summary>
        /// Getters and setters for column Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Getters and setters for column Name
        /// </summary>
        public string Name { get; set; } 
        /// <summary>
        /// Getters and setters for column Number_of_players
        /// </summary>
        public int Number_of_players  { get; set; }
        /// <summary>
        /// Getters and setters for column availability
        /// </summary>
        public bool? availability { get; set; }

        // 1 : * z BoardGameComment
        /// <summary>
        /// Getters and setters for column Comments
        /// </summary>
        public List<BoardGameComment> Comments { get; set; } = new List<BoardGameComment>();
        // 1 : * z Transaction
        /// <summary>
        /// Getters and setters for column Transactions
        /// </summary>
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        //* : * z Tag
        /// <summary>
        /// Getters and setters for column Tags
        /// </summary>
        public List<Tag> Tags { get; set; }
    }
}
