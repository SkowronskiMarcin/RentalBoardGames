namespace RentalBoardGames.Entities
{
    public class Adress
    {
        public int Id { get; set; }
        public string Coutry { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

        // 1 : 1 z Userem
        public User User { get; set; }
        public int UserId { get; set; } //Klucz obcy
    }
}
