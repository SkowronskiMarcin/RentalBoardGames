namespace RentalBoardGames.Entities.ViewModels
{
    /// <summary>
    /// Klasa do utworzenia widoku gier niedostępnych
    /// </summary>
    public class NotAvailableGame
    {
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public string FullName { get; set; }

    }
}
