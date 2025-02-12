using System.Linq.Expressions;

namespace DataAccess.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> GetAll(Expression<Func<T, bool>>? filter = null, bool include = false);
        Task<T?> Get(Expression<Func<T, bool>> filter, bool include = false);
        Task<T?> Add(T entity);
        T? Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
