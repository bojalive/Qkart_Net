global using System.ComponentModel.DataAnnotations;

namespace Qkart_WebAPI.Models.dto
{
    public class ProductsDTO
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
        public string? Catagory { get; set; }
        [Required]
        public int Cost { get; set; }
        public double Rating { get; set; }
        public string? Image { get; set; }
    }
}
