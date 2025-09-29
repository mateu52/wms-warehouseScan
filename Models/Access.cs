namespace wmsmagazyn.Models
{
    public class Access
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AllowedOperation { get; set; } = string.Empty; // np. "Przyjęcie,Wydanie,Przesunięcie"
    }
}

