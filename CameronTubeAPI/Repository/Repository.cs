using CameronTubeAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace CameronTubeAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CamDbContext _db;
        private readonly DbSet<T> _dbSet;

        public Repository(CamDbContext db)
        {
            this._db = db;
            this._dbSet = db.Set<T>();
        }
        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await this.Save();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, int pageSize = 0, int pageNumber = 1)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {

                query = query.Where(filter);

            }
            if (pageSize > 0)
            {
                if (pageSize > 100)
                {
                    pageSize = 100;
                }

                query = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
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
        public async Task UpdateAsync(T entity)
        {

            _dbSet.Update(entity);
            await this.Save();
        }


    }
}
