using System.Collections.Generic;
using MetrianApp.Core.Repositories;
using System.Threading.Tasks;

namespace MetrianApp.Core.Models.Repositories.User
{
  public interface IUserRepository : IRepository<MetrianApp.Core.Models.User>
  {
    Task<IEnumerable<MetrianApp.Core.Models.User>> GetAllUsersAsync();
    Task<MetrianApp.Core.Models.User> GetUserByIdAsync(int id);
  }
}