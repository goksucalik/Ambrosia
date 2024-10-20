using Ambrosia.Data.Abstract;
using Ambrosia.Entities.Concrete;
using Ambrosia.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Ambrosia.Data.Concrete.EntityFramework.Repositories
{
    public class EfCategoryRepository : EfEntityRepositoryBase<Category>, ICategoryRepository
    {
        public EfCategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
