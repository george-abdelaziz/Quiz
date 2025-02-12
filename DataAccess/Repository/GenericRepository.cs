using DataAccess.Interface;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly QuizContext _db;
        internal DbSet<T> dbSet;
        public GenericRepository(QuizContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public virtual async Task<T?> Add(T entity)
        {
            if (entity == null)
            {
                return null;
            }
            await dbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<T?> Get(Expression<Func<T, bool>> filter, bool include = false)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<ICollection<T>> GetAll(Expression<Func<T, bool>>? filter, bool include = false)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public virtual T? Remove(T entity)
        {
            dbSet.Remove(entity);
            return entity;
        }

        public virtual void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

    }
}
