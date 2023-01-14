namespace RentalBoardGames.Entities
{
    /// <summary>
    /// Class entity for Adress Board game table
    /// </summary>
    public class Adress
    {
        /// <summary>
        /// Getters and setters for column Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Getters and setters for column Coutry
        /// </summary>
        public string Coutry { get; set; }
        /// <summary>
        /// Getters and setters for column City
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Getters and setters for column Street
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Getters and setters for column PostalCode
        /// </summary>
        public string PostalCode { get; set; }
        
        // 1 : 1 z Userem
        /// <summary>
        /// Getters and setters for column User
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// Getters and setters for column UserId
        /// </summary>
        public int UserId { get; set; } //Klucz obcy
    }
}
