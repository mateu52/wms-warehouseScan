using System.Text.Json.Serialization;

namespace wmsmagazyn.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // "Magazynier", "Kierownik" lub "Administrator"
        public string Password { get; set; } = string.Empty; 


        // relacja - produkty dodane przez użytkownika
        [JsonIgnore]   // <- ignorujemy przy serializacji
        public List<Product>? Products { get; set; }
    }
}
