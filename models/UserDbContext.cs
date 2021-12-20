using System;
using Microsoft.EntityFrameworkCore;

namespace KeebClack.API.models
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            GenerateInitialTestUsers();
        }

        private void GenerateInitialTestUsers()
        {
            Users.Add(new User { Email = "someTestEmail@gmail.com", Username = "TestUser", Password = "testPassword", DateJoined = new DateTime() });
        }

      //public List<User> getUsers()
        //]eturn Users; }
    }
}
