global using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Qkart_WebAPI.Models;

namespace Qkart_WebAPI.Data
{
    public class QkartDbContext : IdentityDbContext<ApplicationUser>
    {
        public QkartDbContext(DbContextOptions<QkartDbContext> options)
            : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<LinkProductSeller> LinkProductSellers { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
                   ProductId = new Guid("ebed91bc-19d2-401f-843a-0491d21b8770"),
                   SellerId = 1

               },
                new LinkProductSeller
                {
                    Id = 2,
                    ProductId = new Guid("ebed91bc-19d2-401f-843a-0491d21b8770"),
                    SellerId = 2

                },
                 new LinkProductSeller
                 {
                     Id = 3,

                     ProductId = new Guid("c25ef392-45c5-4cae-865f-16ce8f9795b7"),
                     SellerId = 1

                 }
              ); ;
        }
    }
}
