namespace RentalBoardGames.Entities
{
    /// <summary>
    /// Klasa dla encji dla użytkowników
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int UserType { get; set; }

        // 1 : 1 z Adressem
        public Adress Adress { get; set; }

        // 1 : * z BoardGames
        public List<BoardGame> Rented_Games { get; set; } = new List<BoardGame>();

        // 1 : * z BoardGameComment
        public List<BoardGameComment> Comments { get; set; } = new List<BoardGameComment>();


        // 1 : * z Transaction
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
