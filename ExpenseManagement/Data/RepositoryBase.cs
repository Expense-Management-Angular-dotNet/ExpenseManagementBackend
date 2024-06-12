using ExpenseManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExpenseManagement.Data
{
    public class RepositoryBase<Tentity , Tcontext> : IRepositoryBase<Tentity> where Tentity : class where Tcontext : DbContext
    {
        protected Tcontext _RepositoryContext;
        protected DbSet<Tentity> dbSet;
        public RepositoryBase(Tcontext context) { 
            this._RepositoryContext= context;
            dbSet=_RepositoryContext.Set<Tentity>();
        }
        public void Create(Tentity entity)
        {
            throw new NotImplementedException();
        }

        public async void Delete(Tentity entity)
        {
              dbSet.Remove(entity);
        }

        public IQueryable<Tentity> FindAll(bool trackChanges)
        {
            IQueryable<Tentity> query = dbSet;
            return query.AsQueryable();
        }

        public IQueryable<Tentity> FindByCondition(Expression<Func<Tentity, bool>> expression, bool trackChanges, Func<IQueryable<Tentity>, IOrderedQueryable<Tentity>> orderBy)
        {
            IQueryable<Tentity> query = dbSet;
            return query.AsQueryable();
        }

        public async  Task<Tentity> FindbyID(string id)
        {   
            return await dbSet.FindAsync(id);
            
        }

        public void Update(Tentity entity)
        {   
            _RepositoryContext.Entry<Tentity>.State = EntityState.Modified;
            dbSet.Update(entity);

        }

        
    }
}
