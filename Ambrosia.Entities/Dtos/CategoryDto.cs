using Ambrosia.Entities.Concrete;
using Ambrosia.Shared.Entities.Abstract;

namespace Ambrosia.Entities.Dtos
{
    public class CategoryDto : DtoGetBase
    {
        public Category Category { get; set; }
    }
}
