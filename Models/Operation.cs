using wmsmagazyn.Models;

namespace wmsmagazyn.Models
{
    public class Operation
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;   // "Przyjęcie", "Wydanie", "Przesunięcie"

        // Którego produktu dotyczy
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        // Ile sztuk / litrów / kg
        public decimal Quantity { get; set; }

        // Skąd i dokąd (opcjonalne)
        public int? LocationFromId { get; set; }
        public Location? LocationFrom { get; set; }

        public int? LocationToId { get; set; }
        public Location? LocationTo { get; set; }

        // Kto wykonał
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
