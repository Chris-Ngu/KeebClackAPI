using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KeebClack.API.models
{
    public class KeyboardDbContext : DbContext
    {
        DbSet<Keyboard> _keyboards { get; set; }

        // called when instance is created
        public KeyboardDbContext(DbContextOptions options) : base(options)
        {
            // populating in memory with some base users
            // This if or in memory databases, do not run this on a db instance
            //GenerateInitialKeyboards();
        }

        private void GenerateInitialKeyboards()
        {
            this._keyboards.Add(new Keyboard { BoardName = "TestBoard1", DateAdded = new DateTime(), Id = 1, Keycaps = "OEM", Switch = "Cherry", Value = 219 });
            this._keyboards.Add(new Keyboard { BoardName = "TestBoard2", DateAdded = new DateTime(), Id = 2, Keycaps = "OEM2", Switch = "Cherry2", Value = 2190 });
            this.SaveChanges();
        }

        // GetAllKeyboards service to retrieve all users
        public List<Keyboard> GetAllKeyboards()
        {
            // upon start up, using local will show all items, not using local will show nothing until local is updated
            //return this._keyboards.Local.ToList();
            //return this._keyboards.ToList();

            return this._keyboards.ToList();
        }

        // returns one keyboard that matches id param
        public Keyboard GetOneKeyboard(int id)
        {
            return this._keyboards.SingleOrDefault<Keyboard>(x => x.Id == id);
        }

        public Keyboard CreateNewKeyboard(Keyboard keyboard)
        {
            keyboard.DateAdded = DateTime.UtcNow;
            this._keyboards.Add(keyboard);
            this.SaveChanges();

            return keyboard;
        }

        public bool DeleteKeyboard(int id)
        {
            try
            {
                this._keyboards.Remove(this._keyboards.Single(x => x.Id == id));
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
