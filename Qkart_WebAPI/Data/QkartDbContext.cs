global using Microsoft.EntityFrameworkCore;

namespace Qkart_WebAPI.Data
{
    public class QkartDbContext : DbContext
    {
        public QkartDbContext(DbContextOptions<QkartDbContext> options)
            : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                 new Product
                 {
                     Id = Guid.NewGuid(),
                     Name = "Asus ZenPhone M2 Mobile Phone",
                     Catagory = "Mobile",
                     Rating = 4,
                     Cost = 12500,
                     CreatedDate = DateTime.Now,
                     UpdatedDate = DateTime.Now

                 },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "MI Some Mobile",
                    Catagory = "Mobile",
                    Rating = 4.1,
                    Cost = 8500,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                }
                );
        }
    }
}
