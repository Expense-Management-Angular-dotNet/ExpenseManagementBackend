using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExpenseManagement.Data;
using ExpenseManagement.Data.Users;
using ExpenseManagement.Entities;

namespace ExpenseManagement.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
        // I don't think this repo is needed since everything is managed by userManager
    {
        public UserRepository(DbContext repositoryContext) : base(repositoryContext)
        {
            // inherits repositoryContext from parent
        }

        public override void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
