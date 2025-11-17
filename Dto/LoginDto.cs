using System.ComponentModel.DataAnnotations;

namespace wmsmagazyn.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Hasło musi mieć od 4 do 50 znaków")]
        public string Password { get; set; } = null!;
    }
}
