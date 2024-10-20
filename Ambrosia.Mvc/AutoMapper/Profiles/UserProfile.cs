using Ambrosia.Entities.Concrete;
using Ambrosia.Entities.Dtos;
using AutoMapper;

namespace Ambrosia.Mvc.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();
            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
