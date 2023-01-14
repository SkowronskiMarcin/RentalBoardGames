namespace RentalBoardGames.Entities
{
    /// <summary>
    /// Class entity for user table
    /// </summary>
    public class User
    {
        /// <summary>
        /// Getters and setters for column Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Getters and setters for column FirstName
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Getters and setters for column LastName
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Getters and setters for column Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Getters and setters for column UserType
        /// </summary>
        public int UserType { get; set; }

        // 1 : 1 z Adressem
        /// <summary>
        /// Getters and setters for column Adress
        /// </summary>
        public Adress Adress { get; set; }
        
        // 1 : * z BoardGames
        /// <summary>
        /// Getters and setters for column Rented_Games
        /// </summary>
        public List<BoardGame> Rented_Games { get; set; } = new List<BoardGame>();

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
    }
}
