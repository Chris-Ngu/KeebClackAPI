// Reference: https://chathuranga94.medium.com/connect-database-to-asp-net-core-web-api-63a53e8da1ca

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KeebClack.API.models
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> _User { get; set; }

        // called when instance is created
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            // populating in memory with some base users
            GenerateInitialTestUsers();
        }

        private void GenerateInitialTestUsers()
        {
            this._User.Add(new User { Email = "someTestEmail@gmail.com", Username = "TestUser", Password = "testPassword", DateJoined = new DateTime() });
        }

        // getUser service to retrieve all users "locally"
        public List<User> getUsers()
        {
            return this._User.Local.ToList();
        }
      
    }
}
