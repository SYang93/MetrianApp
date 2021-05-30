using System;
using System.Threading.Tasks;
using MetrianApp.Core.Models.Repositories.User;

namespace MetrianApp.Core.UnitOfWork
{
  public interface IUnitOfWork : IDisposable
  {
    IUserRepository Users { get; }
    Task<int> CommitAsync();
  }
}