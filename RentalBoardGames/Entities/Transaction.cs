namespace RentalBoardGames.Entities
{
    /// <summary>
    /// Class entity for transaction
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Getters and setters for column Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Getters and setters for column CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Getters and setters for column Deadline
        /// </summary>
        public DateTime Deadline { get; set; }

        // 1 : * z User
        /// <summary>
        /// Getters and setters for column User
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// Getters and setters for column UserId
        /// </summary>
        public int UserId { get; set; } //Klucz obcy

        // * : 1 z BoardGame
        /// <summary>
        /// Getters and setters for column BoardGame
        /// </summary>
        public BoardGame BoardGame { get; set; }
        /// <summary>
        /// Getters and setters for column BoardGameId
        /// </summary>
        public int BoardGameId { get; set; } //Klucz obcy
    }
}
