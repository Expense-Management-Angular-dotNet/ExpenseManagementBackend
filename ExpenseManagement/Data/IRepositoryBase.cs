using System.Linq.Expressions;

namespace ExpenseManagement.Data
{
    public interface IRepositoryBase<TEntity>
    {
        IQueryable<TEntity> FindAll(bool trackChanges);
        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression,
        bool trackChanges,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);

        Task<TEntity> FindById(string id);
        //void Create(TEntity entity);
        void Update(TEntity entity);


        void Delete(TEntity entity);
    }
}
