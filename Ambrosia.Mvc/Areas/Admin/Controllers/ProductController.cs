using Ambrosia.Entities.ComplexTypes;
using Ambrosia.Entities.Concrete;
using Ambrosia.Entities.Dtos;
using Ambrosia.Mvc.Areas.Admin.Models;
using Ambrosia.Mvc.Helpers.Abstract;
using Ambrosia.Services.Abstract;
using Ambrosia.Shared.Utilities.Results.ComplexTypes;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ambrosia.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IToastNotification _toastNotification;

        public ProductController(IProductService productService, ICategoryService categoryService, UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper, IToastNotification toastNotification) : base(userManager, mapper, imageHelper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _productService.GetAllNonDeletedAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var result = await _categoryService.GetAllNonDeletedAndActiveAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(new ProductAddViewModel
                {
                    Categories = result.Data.Categories
                });
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddViewModel productAddViewModel)
        {
            if (ModelState.IsValid)
            {
                var productAddDto = Mapper.Map<ProductAddDto>(productAddViewModel);
                var imageResult = await ImageHelper.Upload(productAddViewModel.Name, productAddViewModel.ThumbnailFile, PictureType.Post);
                productAddDto.Thumbnail = imageResult.Data.FullName;
                var result = await _productService.AddAsync(productAddDto, LoggedInUser.UserName, LoggedInUser.Id);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    _toastNotification.AddSuccessToastMessage(result.Message);
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            var categories = await _categoryService.GetAllNonDeletedAndActiveAsync();
            productAddViewModel.Categories = categories.Data.Categories;
            return View(productAddViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int productId)
        {
            var productResult = await _productService.GetProductUpdateDtoAsync(productId);
            var categoriesResult = await _categoryService.GetAllNonDeletedAndActiveAsync();
            if (productResult.ResultStatus == ResultStatus.Success && categoriesResult.ResultStatus == ResultStatus.Success)
            {
                var productUpdateViewModel = Mapper.Map<ProductUpdateViewModel>(productResult.Data);
                productUpdateViewModel.Categories = categoriesResult.Data.Categories;
                return View(productUpdateViewModel);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateViewModel productUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                bool isNewThumbnailUploaded = false;
                var oldThumbnail = productUpdateViewModel.Thumbnail;
                if (productUpdateViewModel.ThumbnailFile != null)
                {
                    var uploadedImageResult = await ImageHelper.Upload(productUpdateViewModel.Name,
                        productUpdateViewModel.ThumbnailFile, PictureType.Post);
                    productUpdateViewModel.Thumbnail = uploadedImageResult.ResultStatus == ResultStatus.Success
                        ? uploadedImageResult.Data.FullName
                        : "postImages/defaultThumbnail.jpg";
                    if (oldThumbnail != "postImages/defaultThumbnail.jpg")
                    {
                        isNewThumbnailUploaded = true;
                    }
                }
                var productUpdateDto = Mapper.Map<ProductUpdateDto>(productUpdateViewModel);
                var result = await _productService.UpdateAsync(productUpdateDto, LoggedInUser.UserName);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    if (isNewThumbnailUploaded)
                    {
                        ImageHelper.Delete(oldThumbnail);
                    }
                    _toastNotification.AddSuccessToastMessage(result.Message);
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }

            var categories = await _categoryService.GetAllNonDeletedAndActiveAsync();
            productUpdateViewModel.Categories = categories.Data.Categories;
            return View(productUpdateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int productId)
        {
            var result = await _productService.DeleteAsync(productId, LoggedInUser.UserName);
            var productResult = JsonSerializer.Serialize(result);
            return Json(productResult);
        }
        [HttpGet]
        public async Task<JsonResult> GetAllProducts()
        {
            var products = await _productService.GetAllNonDeletedAndActiveAsync();
            var productResult = JsonSerializer.Serialize(products, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(productResult);
        }
    }
}
