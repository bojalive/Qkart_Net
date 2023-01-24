using Microsoft.EntityFrameworkCore;

namespace Qkart_WebAPI.Data
{
    public class QkartDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
    }
}
