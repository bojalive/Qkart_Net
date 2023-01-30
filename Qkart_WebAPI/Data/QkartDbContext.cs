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
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<LinkProductSeller> LinkProductSellers { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
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
            modelBuilder.Entity<Seller>().HasData(
                 new Seller
                 {
                     Id = 1,
                     SellerName = "InsakHomes",
                     City = "Coimbatore",
                     FullAddress = "Coimbatore",
                     SpecialDetails = "",
                     CreatedDate = DateTime.UtcNow
                 },
                 new Seller
                 {
                     Id = 2,
                     SellerName = "DreamCorp",
                     City = "Coimbatore",
                     FullAddress = "Coimbatore",
                     SpecialDetails = "",
                     CreatedDate = DateTime.UtcNow
                 }
                );
            modelBuilder.Entity<LinkProductSeller>().HasData(
               new LinkProductSeller
               {
                   Id = 1,
                   ProductId = new Guid("70C9AF8E-DA97-4C51-68D1-08DAFECA85A2"),
                   SellerId = 1

               },
                new LinkProductSeller
                {
                    Id = 2,
                    ProductId = new Guid("70C9AF8E-DA97-4C51-68D1-08DAFECA85A2"),
                    SellerId = 2

                },
                 new LinkProductSeller
                 {
                     Id = 3,

                     ProductId = new Guid("B44859E1-C104-4450-BF9B-2008A6858187"),
                     SellerId = 1

                 }
              ); ;
        }
    }
}
