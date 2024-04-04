using Demo_Mock_House_Finder.Data;
using Demo_Mock_House_Finder.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Demo_Mock_House_Finder.Repository.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T>  where T : class
    {
        protected readonly ApplicationDbContext _db;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
        }
        public async Task<T> GetByIDAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            if (filter != null)
            {
                query = query.Where(filter);
            }
          

            return await query.ToListAsync();

        }
        public async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            await SaveAsync();
        }
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveAsync();
        }
    }
}
