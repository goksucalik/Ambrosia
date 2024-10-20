using Ambrosia.Entities.Dtos;
using Ambrosia.Shared.Utilities.Results.Abstract;

namespace Ambrosia.Services.Abstract
{
    public interface IProductService
    {
        Task<IDataResult<ProductDto>> GetAsync(int productId);
        Task<IDataResult<ProductUpdateDto>> GetProductUpdateDtoAsync(int productId);
        Task<IDataResult<ProductListDto>> GetAllAsync();
        Task<IDataResult<ProductListDto>> GetAllNonDeletedAsync();
        Task<IDataResult<ProductListDto>> GetAllNonDeletedAndActiveAsync();
        Task<IDataResult<ProductListDto>> GetAllCategoryAsync(int categoryId);
        Task<IDataResult<ProductListDto>> GetAllPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 5, bool isAscending = false);
        Task<IDataResult<ProductDto>> AddAsync(ProductAddDto productAddDto, string createdName, int userId);
        Task<IDataResult<ProductDto>> UpdateAsync(ProductUpdateDto productUpdateDto, string modifiedName);
        Task<IDataResult<ProductDto>> DeleteAsync(int productId, string modifiedName);
        Task<IResult> HardDeleteAsync(int productId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountNonDeletedAsync();
    }
}
