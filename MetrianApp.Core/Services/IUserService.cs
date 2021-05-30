using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetrianApp.Core.Services
{
  public interface IUserService
  {
    Task<IEnumerable<MetrianApp.Core.Models.User>> GetAllUsers();
    Task<MetrianApp.Core.Models.User> GetUserById(int id);
    Task<MetrianApp.Core.Models.User> CreateUser(MetrianApp.Core.Models.User newUser);
    Task UpdateUser(MetrianApp.Core.Models.User userToBeUpdated, MetrianApp.Core.Models.User user);
    Task DeleteUser(MetrianApp.Core.Models.User user);
  }
}