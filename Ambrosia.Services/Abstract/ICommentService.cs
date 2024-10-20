using Ambrosia.Entities.Dtos;
using Ambrosia.Shared.Utilities.Results.Abstract;

namespace Ambrosia.Services.Abstract
{
    public interface ICommentService
    {
        Task<IDataResult<CommentDto>> GetAsync(int commentId);
        Task<IDataResult<CommentUpdateDto>> GetCommentUpdateDtoAsync(int commentId);
        Task<IDataResult<CommentListDto>> GetAllAsync();
        Task<IDataResult<CommentListDto>> GetAllDeletedAsync();
        Task<IDataResult<CommentListDto>> GetAllNonDeletedAsync();
        Task<IDataResult<CommentListDto>> GetAllNonDeletedAndActiveAsync();
        Task<IDataResult<CommentDto>> AddAsync(CommentAddDto commentAddDto);
        Task<IDataResult<CommentDto>> UpdateAsync(CommentUpdateDto commentUpdateDto, string modifiedName);
        Task<IDataResult<CommentDto>> DeleteAsync(int commentId, string modifiedName);
        Task<IResult> HardDeleteAsync(int commentId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountNonDeletedAsync();
    }
}
