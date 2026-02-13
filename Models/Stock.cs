namespace wmsmagazyn.Models
{
    public class Stock
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public decimal Quantity { get; set; }
    }

}
