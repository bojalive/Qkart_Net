using Qkart_WebAPI.Data;
using System.Linq.Expressions;

namespace Qkart_WebAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly QkartDbContext _db;
        private readonly DbSet<T> _dbSet;

        public Repository(QkartDbContext db)
        {
            this._db = db;
            this._dbSet = db.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await this.Save();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {

                query = query.Where(filter);

            }
            return await query.ToListAsync();

        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>>? filter = null, bool tracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (!tracking) query = query.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (query.Count() > 0) return await query.FirstAsync();
            return null;
        }

        public async Task RemoveAsync(T entity)
        {

            _dbSet.Remove(entity);
            await this.Save();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
