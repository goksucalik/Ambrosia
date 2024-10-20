using Ambrosia.Entities.Dtos;
using Ambrosia.Shared.Utilities.Results.Abstract;

namespace Ambrosia.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> GetAsync(int categoryId);
        Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDtoAsync(int categoryId);
        Task<IDataResult<CategoryListDto>> GetAllAsync();
        Task<IDataResult<CategoryListDto>> GetAllNonDeletedAsync();
        Task<IDataResult<CategoryListDto>> GetAllNonDeletedAndActiveAsync();
        Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto categoryAddDto, string createdName);
        Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto, string modifiedName);
        Task<IDataResult<CategoryDto>> DeleteAsync(int categoryId, string modifiedName);
        Task<IResult> HardDeleteAsync(int categoryId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountNonDeletedAsync();
    }
}
