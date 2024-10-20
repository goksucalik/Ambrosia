using Ambrosia.Shared.Entities.Abstract;
using System.Linq.Expressions;

namespace Ambrosia.Shared.Data.Abstract
{
    public interface IGenericRepository<T>
        where T : class, IEntity, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
        Task<int> CountAsync(Expression<Func<T, bool>> filter = null);
    }
}
