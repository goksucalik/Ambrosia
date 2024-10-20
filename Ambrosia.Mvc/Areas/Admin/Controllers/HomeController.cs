using Ambrosia.Entities.Concrete;
using Ambrosia.Mvc.Areas.Admin.Models;
using Ambrosia.Services.Abstract;
using Ambrosia.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ambrosia.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;
        private readonly UserManager<User> _userManager;

        public HomeController(ICategoryService categoryService, IProductService productService, ICommentService commentService, UserManager<User> userManager)
        {
            _categoryService = categoryService;
            _productService = productService;
            _commentService = commentService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var categoriesCountResult = await _categoryService.CountNonDeletedAsync();
            var productsCountResult = await _productService.CountNonDeletedAsync();
            var commentsCountResult = await _commentService.CountNonDeletedAsync();
            var usersCount = await _userManager.Users.CountAsync();
            var productsResult = await _productService.GetAllAsync();
            if (categoriesCountResult.ResultStatus == ResultStatus.Success && productsCountResult.ResultStatus == ResultStatus.Success && commentsCountResult.ResultStatus == ResultStatus.Success && usersCount > -1 && productsResult.ResultStatus == ResultStatus.Success)
            {
                return View(new DashboardViewModel
                {
                    CategoriesCount = categoriesCountResult.Data,
                    ProductsCount = productsCountResult.Data,
                    CommentsCount = commentsCountResult.Data,
                    UsersCount = usersCount,
                    Products = productsResult.Data
                });
            }
            return NotFound();
        }
    }
}
