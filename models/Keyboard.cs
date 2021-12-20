using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeebClack.API.models
{
    public class Keyboard
    {
        public int Id { get; set; }
        public string BoardName { get; set; }
        public string Switch { get; set; }
        public string Keycaps { get; set; }
        public int Value { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
