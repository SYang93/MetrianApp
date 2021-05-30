using System.Threading.Tasks;
using MetrianApp.Core.UnitOfWork;
using MetrianApp.Core.Models.Repositories.User;
using MetrianApp.Data.DbContexts;
using MetrianApp.Data.Repositories;

namespace MetrianApp.Data.UnitOfWork
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly UserDbContext _context;
    private UserRepository _userRepository;
    public UnitOfWork(UserDbContext context)
    {
      this._context = context;
    }

    public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);

    public async Task<int> CommitAsync()
    {
      return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
      _context.Dispose();
    }
  }
}