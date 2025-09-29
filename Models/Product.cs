using wmsmagazyn.Models;

namespace wmsmagazyn.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public decimal Price { get; set; }

        // Opcjonalnie: domyślna lokalizacja przy pierwszym przyjęciu
        public int? DefaultLocationId { get; set; }
        public Location? DefaultLocation { get; set; }
    }
}
