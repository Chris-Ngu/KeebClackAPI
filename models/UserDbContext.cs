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
            // This is for in memory database testing
            // Do not run this on a db instance
           // GenerateInitialTestUsers();
        }

        private void GenerateInitialTestUsers()
        {
            this._User.Add(new User { Email = "test1@gmail.com", Username = "TestUserOne", Password = "testPassword", DateJoined = new DateTime() });
            this._User.Add(new User { Email = "test2@gmail.com", Username = "TestUserTwo", Password = "testPassword", DateJoined = new DateTime() });
            this.SaveChanges();
        }

        // getUser service to retrieve all users "locally"
        public List<User> getUsers()
        {

            return this._User.ToList();
            //return this._User.Local.ToList();
        }

        public User GetUser(string email)
        {
            // returns null if DNE (because of Single instead of SingleOrDefault
            return this._User.SingleOrDefault<User>(x => x.Email == email);
        }

        public User AddUser(User user)
        {
            user.DateJoined = DateTime.UtcNow;
            this._User.Add(user);
            this.SaveChanges();
            return user;
        }

        public bool DeleteUser(string email)
        {
            try
            {
                this._User.Remove(this._User.Single(x => x.Email == email));
                this.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // need update function here
      
    }
}
