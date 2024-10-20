using Ambrosia.Entities.Concrete;
using Ambrosia.Shared.Entities.Abstract;

namespace Ambrosia.Entities.Dtos
{
    public class ProductListDto : DtoGetBase
    {
        public IList<Product> Products { get; set; }
        public int? CategoryId { get; set; }
    }
}
