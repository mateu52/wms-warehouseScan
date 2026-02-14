namespace wmsmagazyn.Models
{
    public class StockMovement
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public decimal Quantity { get; set; }

        public MovementType Type { get; set; } // IN / OUT

        public DateTime CreatedAt { get; set; }
    }
    public enum MovementType
    {
        IN = 1,
        OUT = 2
    }



}
