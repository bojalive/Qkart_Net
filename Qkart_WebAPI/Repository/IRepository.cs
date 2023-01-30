using System.Linq.Expressions;

namespace Qkart_WebAPI.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? entity = null, int pageSize = 0, int pageNumber = 1);
        Task<T> GetByIdAsync(Expression<Func<T, bool>>? entity = null, bool tracking = true);
        Task CreateAsync(T entity);
        Task RemoveAsync(T entity);

        Task UpdateAsync(T entity);
        Task Save();

    }
}
