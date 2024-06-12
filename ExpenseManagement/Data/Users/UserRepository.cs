using ExpenseManagement.Entities;

namespace ExpenseManagement.Data.Users
{
    public class UserRepository:RepositoryBase<User, ApplicationDbContext>, IUserRepository
    {
        public UserRepository(ApplicationDbContext applicationDbContext) 
        : base(applicationDbContext) 
        {

        }
    }
}
