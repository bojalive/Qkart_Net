global using AutoMapper;
global using Qkart_WebAPI.Models.dto;
using Qkart_WebAPI.Models.SellerDTO;

namespace Qkart_WebAPI.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();

            CreateMap<Product, ProductCreateDTO>().ReverseMap();
            CreateMap<Product, ProductOnlyDTO>().ReverseMap();
            CreateMap<Seller, SellerCreateDTO>().ReverseMap();
            CreateMap<Seller, SellerDTO>().ReverseMap();
        }
    }
}
