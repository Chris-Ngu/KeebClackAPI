﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KeebClack.API.models
{
    public class User
    {
        [Key]
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateJoined { get; set; }
        //public ICollection<Keyboard> Keyboards { get; set; }
    }
}
