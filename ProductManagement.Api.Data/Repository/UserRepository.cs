using ProductManagement.Api.Data.Interface;
using ProductManagement.Api.Data.Models;

namespace ProductManagement.Api.Data.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
        }
    }
}
