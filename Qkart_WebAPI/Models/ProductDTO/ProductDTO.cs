global using System.ComponentModel.DataAnnotations;

namespace Qkart_WebAPI.Models.dto
{
    public class ProductDTO
    {
        //[Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
        public string? Catagory { get; set; }
        [Required]
        public int Cost { get; set; }
        public double Rating { get; set; }
        public string? Image { get; set; }
        public List<Seller> Sellers { get; set; } = new List<Seller>();
    }
}
