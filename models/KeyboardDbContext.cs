// Reference: https://chathuranga94.medium.com/connect-database-to-asp-net-core-web-api-63a53e8da1ca

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KeebClack.API.models
{
    public class KeyboardDbContext : DbContext
    {
        public DbSet<Keyboard> Keyboards { get; set; }

        public KeyboardDbContext(DbContextOptions<KeyboardDbContext> context) : base(options)
        {
            GenerateInitialKeyboards();
        }

        private void GenerateInitialKeyboards()
        {
            Keyboards.Add(new Keyboard { Id = 1, BoardName = "KreeseBoard", Switch = "brown", Keycaps = "OEM", Value = 129, DateAdded = new DateTime() });
        }


        public List<Keyboard> getKeyboards()
        {
            return Keyboards.Local.toList<Keyboard>();
        }
    }
}
