using Ambrosia.Entities.Concrete;
using Ambrosia.Shared.Entities.Abstract;

namespace Ambrosia.Entities.Dtos
{
    public class CommentDto : DtoGetBase
    {
        public Comment Comment { get; set; }
    }
}
