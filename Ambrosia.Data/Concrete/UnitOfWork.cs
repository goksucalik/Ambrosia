using Ambrosia.Data.Abstract;
using Ambrosia.Data.Concrete.EntityFramework.Context;
using Ambrosia.Data.Concrete.EntityFramework.Repositories;

namespace Ambrosia.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AmbrosiaContext _context;
        private EfBasketRepository _basketRepository;
        private EfCategoryRepository _categoryRepository;
        private EfCommentRepository _commentRepository;
        private EfProductRepository _productRepository;
        public UnitOfWork(AmbrosiaContext context)
        {
            _context = context;
        }
        public IBasketRepository Basket => _basketRepository ??= new EfBasketRepository(_context);

        public ICategoryRepository Categories => _categoryRepository ??= new EfCategoryRepository(_context);

        public ICommentRepository Comments => _commentRepository ??= new EfCommentRepository(_context);

        public IProductRepository Products => _productRepository ??= new EfProductRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
