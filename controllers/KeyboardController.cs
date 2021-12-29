using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KeebClack.API.models;

namespace KeebClack.API.controllers
{
    [Route("api/keyboard")]
    [ApiController]
    public class KeyboardController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public KeyboardController(DatabaseContext context)
        {
            this._context = context;
        }

        // returns all keyboards
        [HttpGet]
        public async Task<IActionResult> GetAllKeyboards()
        {
            return Ok(this._context.GetAllKeyboards());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneKeybard(int id)
        {
            return Ok(this._context.GetOneKeyboard(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateKeyboard(Keyboard keyboard)
        {
            return Ok(this._context.CreateNewKeyboard(keyboard));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKeyboard(int id)
        {
            bool status = this._context.DeleteKeyboard(id);
            if (status) return Ok();
            else return BadRequest();
        }
    }
}
