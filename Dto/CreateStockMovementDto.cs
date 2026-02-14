namespace wmsmagazyn.Dto
{
    public class CreateStockMovementDto
    {
        public int ProductId { get; set; }
        public int LocationId { get; set; }
        public decimal Quantity { get; set; }
    }

}
