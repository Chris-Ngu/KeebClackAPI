using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KeebClack.API.models
{
    public class User
    {
 
        public int Id { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Username { get; set; }
        
        [Required]
        
        public string Password { get; set; }
        public DateTime DateJoined { get; set; }

        //[InverseProperty("Keyboards")]
        public List<Keyboard> Keyboards { get; set; }
    }
}
