using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MetrianApp.Core.Models.Repositories.User;
using MetrianApp.Data.DbContexts;

namespace MetrianApp.Data.Repositories
{
  public class UserRepository : Repository<MetrianApp.Core.Models.User>, IUserRepository
  {
    private UserDbContext UserDbContext
    {
      get { return Context as UserDbContext; }
    }
    public UserRepository(UserDbContext context)
            : base(context)
    { }

    public async Task<IEnumerable<MetrianApp.Core.Models.User>> GetAllUsersAsync()
    {
      return await UserDbContext.Users.ToListAsync();
    }
    public async Task<MetrianApp.Core.Models.User> GetUserByIdAsync(int id)
    {
      return await UserDbContext.Users.SingleOrDefaultAsync(user => user.Id == id);
    }
  }
}