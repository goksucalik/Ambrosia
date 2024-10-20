using Ambrosia.Entities.Concrete;
using Ambrosia.Entities.Dtos;
using AutoMapper;

namespace Ambrosia.Services.AutoMapper.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductAddDto, Product>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ProductUpdateDto, Product>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Product, ProductUpdateDto>();
        }
    }
}
