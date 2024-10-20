using Ambrosia.Entities.Dtos;
using Ambrosia.Mvc.Areas.Admin.Models;
using AutoMapper;

namespace Ambrosia.Mvc.AutoMapper.Profiles
{
    public class ViewModelsProfile : Profile
    {
        public ViewModelsProfile()
        {
            CreateMap<ProductAddViewModel, ProductAddDto>();
            CreateMap<ProductUpdateDto, ProductUpdateViewModel>().ReverseMap();
        }
    }
}
