using System.Threading.Tasks;
using System.Collections.Generic;
using MetrianApp.Core.Services;
using MetrianApp.Core.UnitOfWork;

namespace MetrianApp.Services
{
  public class UserService : IUserService
  {
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
      this._unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<MetrianApp.Core.Models.User>> GetAllUsers()
    {
      return await _unitOfWork.Users.GetAllUsersAsync();
    }
    public async Task<MetrianApp.Core.Models.User> GetUserById(int id)
    {
      return await _unitOfWork.Users
                 .GetUserByIdAsync(id);
    }
    public async Task<MetrianApp.Core.Models.User> CreateUser(MetrianApp.Core.Models.User newUser)
    {
      await _unitOfWork.Users.AddAsync(newUser);
      await _unitOfWork.CommitAsync();
      return newUser;
    }
    public async Task UpdateUser(MetrianApp.Core.Models.User userToBeUpdated, MetrianApp.Core.Models.User user)
    {
      userToBeUpdated.FirstName = user.FirstName;
      userToBeUpdated.LastName = user.LastName;

      await _unitOfWork.CommitAsync();
    }
    public async Task DeleteUser(MetrianApp.Core.Models.User user)
    {
      _unitOfWork.Users.Remove(user);
      await _unitOfWork.CommitAsync();
    }
  }
}