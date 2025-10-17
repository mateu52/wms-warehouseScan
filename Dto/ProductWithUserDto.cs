namespace wmsmagazyn.Dto
{
    public class ProductWithUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Barcode { get; set; } = null!;
        public string Unit { get; set; } = null!;
        public decimal Price { get; set; }
        public UserDto? CreatedByUser { get; set; } = null!;
    }
}
