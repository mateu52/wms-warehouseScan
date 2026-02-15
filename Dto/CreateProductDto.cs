using System.ComponentModel.DataAnnotations;

namespace wmsmagazyn.Dto
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Nazwa produktu jest wymagana")]
        [StringLength(100, ErrorMessage = "Nazwa produktu może mieć maksymalnie 100 znaków")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Cena jest wymagana")]
        [Range(0.01, 100000, ErrorMessage = "Cena musi być większa niż 0")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "Jednostka jest wymagana")]
        public string Unit { get; set; } = null!;
    }
}
