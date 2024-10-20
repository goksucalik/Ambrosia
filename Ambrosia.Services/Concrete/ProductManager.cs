using Ambrosia.Data.Abstract;
using Ambrosia.Entities.Concrete;
using Ambrosia.Entities.Dtos;
using Ambrosia.Services.Abstract;
using Ambrosia.Services.Utilities;
using Ambrosia.Shared.Utilities.Results.Abstract;
using Ambrosia.Shared.Utilities.Results.ComplexTypes;
using Ambrosia.Shared.Utilities.Results.Concrete;
using AutoMapper;
namespace Ambrosia.Services.Concrete
{
    public class ProductManager : ManagerBase, IProductService
    {
        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<IDataResult<ProductDto>> AddAsync(ProductAddDto productAddDto, string createdName, int userId)
        {
            var product = Mapper.Map<Product>(productAddDto);
            product.CreatedName = createdName;
            product.ModifiedName = createdName;
            product.UserId = userId;
            var addedProduct = await UnitOfWork.Products.AddAsync(product);
            await UnitOfWork.SaveAsync();
            return new DataResult<ProductDto>(ResultStatus.Success, Messages.Product.Add(addedProduct.Name), new ProductDto
            {
                Product = addedProduct,
                ResultStatus = ResultStatus.Success,
                Message = Messages.Product.Add(addedProduct.Name)
            });
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var productsCount = await UnitOfWork.Products.CountAsync();
            if (productsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, productsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<int>> CountNonDeletedAsync()
        {
            var productsCount = await UnitOfWork.Products.CountAsync(p => p.IsDeleted);
            if (productsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, productsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<ProductDto>> DeleteAsync(int productId, string modifiedName)
        {
            var product = await UnitOfWork.Products.GetAsync(p => p.Id == productId);
            if (product != null)
            {
                product.IsDeleted = true;
                product.IsActive = false;
                product.ModifiedName = modifiedName;
                product.ModifiedDate = DateTime.Now;
                var deletedProduct = await UnitOfWork.Products.UpdateAsync(product);
                await UnitOfWork.SaveAsync();
                return new DataResult<ProductDto>(ResultStatus.Success, Messages.Product.Delete(deletedProduct.Name), new ProductDto
                {
                    Product = deletedProduct,
                    ResultStatus = ResultStatus.Success,
                    Message = Messages.Product.Delete(deletedProduct.Name)

                });
            }
            return new DataResult<ProductDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: false), new ProductDto
            {
                Product = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Product.NotFound(isPlural: false)
            });
        }

        public async Task<IDataResult<ProductListDto>> GetAllAsync()
        {
            var products = await UnitOfWork.Products.GetAllAsync(null, p => p.User, p => p.Category);
            if (products.Count > -1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products = products,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: true), new ProductListDto
            {
                Products = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Product.NotFound(isPlural: true)
            });
        }

        public async Task<IDataResult<ProductListDto>> GetAllCategoryAsync(int categoryId)
        {
            var result = await UnitOfWork.Categories.AnyAsync(c => c.Id == categoryId);
            if (result)
            {
                var products = await UnitOfWork.Products.GetAllAsync(
                    a => a.CategoryId == categoryId && !a.IsDeleted && a.IsActive, a => a.User, a => a.Category);
                if (products.Count > -1)
                {
                    return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                    {
                        Products = products,
                        ResultStatus = ResultStatus.Success
                    });
                }
                return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: true), null);
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: false), null);

        }

        public async Task<IDataResult<ProductListDto>> GetAllNonDeletedAndActiveAsync()
        {
            var products = await UnitOfWork.Products.GetAllAsync(p => !p.IsDeleted && p.IsActive, p => p.User, p => p.Category);
            if (products.Count > -1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products = products,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<ProductListDto>> GetAllNonDeletedAsync()
        {
            var products = await UnitOfWork.Products.GetAllAsync(p => !p.IsDeleted, p => p.User, p => p.Category);
            if (products.Count > -1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products = products,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<ProductListDto>> GetAllPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            var products = categoryId == null
                ? await UnitOfWork.Products.GetAllAsync(p => p.IsActive && !p.IsDeleted, p => p.Category, p => p.User)
                : await UnitOfWork.Products.GetAllAsync(p => p.CategoryId == categoryId && p.IsActive && !p.IsDeleted, p => p.Category, p => p.User);
            var sortedProducts = isAscending
                ? products.OrderBy(p => p.Price).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : products.OrderByDescending(p => p.Price).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
            {
                Products = sortedProducts,
                CategoryId = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = products.Count,
                IsAscending = isAscending
            });
        }

        public async Task<IDataResult<ProductDto>> GetAsync(int productId)
        {
            var product = await UnitOfWork.Products.GetAsync(p => p.Id == productId, p => p.User, p => p.Category);
            if (product != null)
            {
                return new DataResult<ProductDto>(ResultStatus.Success, new ProductDto
                {
                    Product = product,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: false), null);
        }
        public async Task<IDataResult<ProductUpdateDto>> GetProductUpdateDtoAsync(int productId)
        {
            var result = await UnitOfWork.Products.AnyAsync(p => p.Id == productId);
            if (result)
            {
                var product = await UnitOfWork.Products.GetAsync(p => p.Id == productId);
                var productUpdateDto = Mapper.Map<ProductUpdateDto>(product);
                return new DataResult<ProductUpdateDto>(ResultStatus.Success, productUpdateDto);
            }
            else
            {
                return new DataResult<ProductUpdateDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: false), null);
            }
        }
        public async Task<IResult> HardDeleteAsync(int productId)
        {
            var result = await UnitOfWork.Products.AnyAsync(p => p.Id == productId);
            if (result)
            {
                var product = await UnitOfWork.Products.GetAsync(p => p.Id == productId);
                await UnitOfWork.Products.DeleteAsync(product);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Product.HardDelete(product.Name));
            }
            return new Result(ResultStatus.Error, Messages.Product.NotFound(isPlural: false));

        }

        public async Task<IDataResult<ProductDto>> UpdateAsync(ProductUpdateDto productUpdateDto, string modifiedName)
        {
            var oldProduct = await UnitOfWork.Products.GetAsync(p => p.Id == productUpdateDto.Id);
            var product = Mapper.Map<ProductUpdateDto, Product>(productUpdateDto, oldProduct);
            product.ModifiedName = modifiedName;
            var updatedProduct = await UnitOfWork.Products.UpdateAsync(product);
            await UnitOfWork.SaveAsync();
            return new DataResult<ProductDto>(ResultStatus.Success, Messages.Product.Add(updatedProduct.Name), new ProductDto
            {
                Product = updatedProduct,
                ResultStatus = ResultStatus.Success,
                Message = Messages.Product.Add(updatedProduct.Name)
            });
        }
    }
}
