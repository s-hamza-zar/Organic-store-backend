using AutoMapper;
using organicEcomApi.Dto;
using organicEcomApi.Models;

namespace organicEcomApi.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
