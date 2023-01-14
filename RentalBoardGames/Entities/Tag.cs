namespace RentalBoardGames.Entities
{
    /// <summary>
    /// Klasa dla encji tagów
    /// </summary>
    public class Tag
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public List<BoardGame> BoardGames { get; set; }
    }
}
