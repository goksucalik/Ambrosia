using Ambrosia.Entities.Dtos;
using Ambrosia.Services.Abstract;
using Ambrosia.Shared.Utilities.Results.ComplexTypes;
using Ambrosia.Shared.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Ambrosia.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(int? categoryId, int currentPage = 1, int pageSize = 5, bool isAscending = false, string sortOrder = "default")
        {
            var productsResult = await (categoryId == null
                ? _productService.GetAllPagingAsync(null, currentPage, pageSize, isAscending)
                : _productService.GetAllPagingAsync(categoryId.Value, currentPage, pageSize, isAscending));

            if (productsResult.ResultStatus == ResultStatus.Success)
            {
                var products = productsResult.Data.Products;
                if (string.IsNullOrEmpty(sortOrder) || sortOrder == "default")
                {
                    products = products.OrderBy(x => Guid.NewGuid()).ToList(); // Karışık sıralama
                }
                else
                {
                    if (isAscending)
                    {
                        products = products.OrderBy(p => p.Price).ToList();
                    }
                    else
                    {
                        products = products.OrderByDescending(p => p.Price).ToList();
                    }
                }
                productsResult.Data.Products = products;
                return View(productsResult.Data);
            }
            return NotFound();
        }


        public async Task<IActionResult> Detail(int productId)
        {
            var productResult = await _productService.GetAsync(productId);
            if (productResult.ResultStatus == ResultStatus.Success)
            {
                return View(productResult.Data);
            }
            return NotFound();
        }
        public async Task<IActionResult> Food(int categoryId)
        {
            var result = await _productService.GetAllCategoryAsync(categoryId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                ViewBag.DesiredCategoryId = categoryId;
                return View(result.Data);
            }
            return NotFound();
        }
    }
}
