namespace Qkart_WebAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Catagory { get; set; }
        public int Cost { get; set; }
        public double Rating { get; set; }
        public string? Image { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
