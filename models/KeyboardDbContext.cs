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
            GenerateInitialKeyboards();
        }

        private void GenerateInitialKeyboards()
        {
            _keyboards.Add(new Keyboard { BoardName = "TestBoard1", DateAdded = new DateTime(), Id = 1, Keycaps = "OEM", Switch = "Cherry", Value = 219 });
            _keyboards.Add(new Keyboard { BoardName = "TestBoard2", DateAdded = new DateTime(), Id = 2, Keycaps = "OEM2", Switch = "Cherry2", Value = 2190 });
        }

        // GetAllKeyboards service to retrieve all users "locally"
        public List<Keyboard> GetAllKeyboards()
        {
            return this._keyboards.Local.ToList();
        }

        // returns one keyboard that matches id param
        public Keyboard GetOneKeyboard(int id)
        {
            return this._keyboards.Local.SingleOrDefault<Keyboard>(x => x.Id == id);
        }
    }
}
