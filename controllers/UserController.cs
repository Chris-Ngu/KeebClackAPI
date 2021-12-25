using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using KeebClack.API.models;

namespace KeebClack.API.controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _context;
        public UserController(UserDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            List<User> users = this._context.getUsers();
            return Ok(users);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetOneUser(string email)
        {
            return Ok(this._context.GetUser(email));
        }
    }
}
