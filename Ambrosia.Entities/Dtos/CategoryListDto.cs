using Ambrosia.Entities.Concrete;
using Ambrosia.Shared.Entities.Abstract;

namespace Ambrosia.Entities.Dtos
{
    public class CategoryListDto : DtoGetBase
    {
        public IList<Category> Categories { get; set; }
    }
}
