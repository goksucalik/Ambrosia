namespace Ambrosia.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IBasketRepository Basket { get; }
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        IProductRepository Products { get; }
        Task<int> SaveAsync();
    }
}
