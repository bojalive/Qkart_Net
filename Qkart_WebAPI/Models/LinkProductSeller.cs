using System.ComponentModel.DataAnnotations.Schema;

namespace Qkart_WebAPI.Models
{
    public class LinkProductSeller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        [ForeignKey("Seller")]
        public int SellerId { get; set; }
        public Seller? Seller { get; set; }
        public int SellerPrice { get; set; }
        public string? SpecialDetails { get; set; }
    }
}
