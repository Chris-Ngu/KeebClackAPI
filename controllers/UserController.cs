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
        private readonly DatabaseContext _context;
        public UserController(DatabaseContext context)
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

        [HttpPost]
        public async Task<IActionResult> AddNewUser(User user)
        { 
            return Ok(this._context.AddUser(user));
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteUser(string email)
        {
            bool status = this._context.DeleteUser(email);
            if (status) return Ok();
            else return BadRequest();
        }

        // need an update endpoint here
    }
}
