using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Data
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected DbContext RepositoryContext { get; set; }

        public RepositoryBase(DbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<TEntity> FindAll(bool trackChanges)
        {
            return !trackChanges ?
                RepositoryContext.Set<TEntity>()
                    .AsNoTracking() :
                RepositoryContext.Set<TEntity>();
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = !trackChanges ?
                RepositoryContext.Set<TEntity>()
                    .Where(expression)
                    .AsNoTracking() :
                RepositoryContext.Set<TEntity>()
                    .Where(expression);

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }

        public async Task<TEntity> FindById(string id)
        {
            return await RepositoryContext.Set<TEntity>().FindAsync(id);
        }

        public void Delete(TEntity entity)
        {
            RepositoryContext.Set<TEntity>().Remove(entity);
        }

        //public abstract void Create(TEntity entity);

        public abstract void Update(TEntity entity);
    }
}
