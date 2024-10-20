using Ambrosia.Entities.Concrete;
using Ambrosia.Shared.Entities.Abstract;

namespace Ambrosia.Entities.Dtos
{
    public class UserListDto : DtoGetBase
    {
        public IList<User> Users { get; set; }
    }
}
