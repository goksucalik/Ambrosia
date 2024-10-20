using Ambrosia.Data.Abstract;
using AutoMapper;

namespace Ambrosia.Services.Concrete
{
    public class ManagerBase
    {
        protected IUnitOfWork UnitOfWork { get; set; }
        protected IMapper Mapper { get; set; }
        public ManagerBase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
    }
}
