using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ProductManagement.Api.Data.Interface;

namespace ProductManagement.Api.Data.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class 
    {
        private readonly ApplicationDBContext _dbContext;

        public RepositoryBase(
            ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        
        public async Task<T> GetById(int id)
        {
            var res = await _dbContext.Set<T>().FindAsync(id);
            
            if(res!=null)
              _dbContext.Entry(res).State = EntityState.Detached; 
            
            return res; 
        }

        public async Task Create(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> Find(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(predicate);
        }
    }
}

