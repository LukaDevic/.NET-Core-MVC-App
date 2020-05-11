using AutoMapper;
using MVCCoreApp.Data.Dtos;
using MVCCoreApp.Data.Models;

namespace MVCCoreApp.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<ProductDto, Product>();
        }
    }
}
