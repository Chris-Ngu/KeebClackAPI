using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KeebClack.API.models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Keyboard> Keyboards { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(x => x.Email).IsUnique();
        }

        // ==================== UserDbSet ====================================

        public List<User> getUsers()
        {

            return this.Users.ToList();
            //return this._User.Local.ToList();
        }

        public User GetUser(string email)
        {
            // returns null if DNE (because of Single instead of SingleOrDefault
            return this.Users.SingleOrDefault<User>(x => x.Email == email);
        }

        public User AddUser(User user)
        {
            user.DateJoined = DateTime.UtcNow;
            this.Users.Add(user);
            this.SaveChanges();
            return user;
        }

        public bool DeleteUser(string email)
        {
            try
            {
                this.Users.Remove(this.Users.Single(x => x.Email == email));
                this.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // ======================= KeyboardDbSet ==============================
        public List<Keyboard> GetAllKeyboards()
        { 
            return this.Keyboards.ToList();
        }

        // returns one keyboard that matches id param
        public Keyboard GetOneKeyboard(int id)
        {
            return this.Keyboards.SingleOrDefault<Keyboard>(x => x.Id == id);
        }

        public Keyboard CreateNewKeyboard(Keyboard keyboard)
        {
            keyboard.DateAdded = DateTime.UtcNow;
            this.Keyboards.Add(keyboard);
            this.SaveChanges();

            return keyboard;
        }

        public bool DeleteKeyboard(int id)
        {
            try
            {
                this.Keyboards.Remove(this.Keyboards.Single(x => x.Id == id));
                this.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
