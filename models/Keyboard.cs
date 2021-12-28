using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KeebClack.API.models
{
    public class Keyboard
    {
        public int Id { get; set; }

        [ForeignKey("UserForeignKey")]
        [Required]
        public User User { get; set; }

        [Required]
        public string BoardName { get; set; }

        [Required]
        public string Switch { get; set; }

        [Required]
        public string Keycaps { get; set; }

        public int Value { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
