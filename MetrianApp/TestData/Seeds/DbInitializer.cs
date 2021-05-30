using System;
using System.Linq;
using MetrianApp.Data.DbContexts;
using MetrianApp.Core.Models;

namespace MetrianApp.TestData.Seeds
{
  public static class DbInitializer
  {
    public static void Initialize(UserDbContext context)
    {
      context.Database.EnsureCreated();

      // Look for any students.
      if (context.Users.Any())
      {
        return;   // DB has been seeded
      }

      var users = new User[]
      {
        new User{FirstName="Carson",LastName="Alexander"},
        new User{FirstName="Meredith",LastName="Alonso"},
        new User{FirstName="Arturo",LastName="Anand"},
        new User{FirstName="Gytis",LastName="Barzdukas"},
        new User{FirstName="Yan",LastName="Li"},
        new User{FirstName="Peggy",LastName="Justice"},
        new User{FirstName="Laura",LastName="Norman"},
        new User{FirstName="Nino",LastName="Olivetto"}
      };

      context.Users.AddRange(users);
      context.SaveChanges();
    }
  }
}