using System.Linq.Expressions;

namespace ProductManagement.Api.Data.Interface
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> GetAll();

        Task<T> GetById(int id);

        Task Create(T entity);

        Task Update(T entity);

        Task<bool> Delete(int id);

        Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> predicate);

        Task<T> Find(Expression<Func<T, bool>> predicate);
    }
}

