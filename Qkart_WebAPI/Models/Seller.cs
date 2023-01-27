namespace Qkart_WebAPI.Models
{
    public class Seller
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? SellerName { get; set; }
        public string? City { get; set; }
        [MaxLength(200)]
        public string? FullAddress { get; set; }
        public string? SpecialDetails { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
