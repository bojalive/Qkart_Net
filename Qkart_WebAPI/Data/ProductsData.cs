global using Qkart_WebAPI.Models.dto;

namespace Qkart_WebAPI.Data
{
    public static class ProductsData
    {
        public static List<ProductsDTO> ProductsList = new List<ProductsDTO>()
        {
             new ProductsDTO
                {
                    Id = Guid.NewGuid(),
                    Name = "Asus ZenPhone M2 Mobile Phone",
                    Catagory="Mobile",
                    Rating=4,
                    Cost = 12500

                },
                new ProductsDTO
                {
                     Id = Guid.NewGuid(),
                    Name = "MI Some Mobile",
                    Catagory="Mobile",
                    Rating=4.1,
                    Cost = 8500
                }

        };
    }
}
