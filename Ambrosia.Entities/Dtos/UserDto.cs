using Ambrosia.Entities.Concrete;
using Ambrosia.Shared.Entities.Abstract;

namespace Ambrosia.Entities.Dtos
{
    public class UserDto : DtoGetBase
    {
        public User User { get; set; }
    }
}
