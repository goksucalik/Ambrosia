using Ambrosia.Entities.Dtos;

namespace Ambrosia.Mvc.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int CategoriesCount { get; set; }
        public int ProductsCount { get; set; }
        public int CommentsCount { get; set; }
        public int UsersCount { get; set; }
        public ProductListDto Products { get; set; }
    }
}
