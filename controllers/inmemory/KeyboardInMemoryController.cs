using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KeebClack.API.models;

namespace KeebClack.API.controllers
{
    [Route("api/keyboardinmemory")]
    [ApiController]
    public class KeyboardInMemoryController : ControllerBase
    {
        private readonly ILogger<KeyboardInMemoryController> _logger;
        private readonly KeyboardDbContext _context;

        public KeyboardInMemoryController(ILogger<KeyboardInMemoryController> logger, KeyboardDbContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKeyboards()
        {
            List<Keyboard> keyboards = this._context.GetAllKeyboards();
            return Ok(keyboards);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneKeyboard(int id)
        {
            Keyboard keyboard = this._context.GetOneKeyboard(id);
            return Ok(keyboard);
        }

        [HttpPost]
        public async Task<IActionResult> createKeyboard(Keyboard keyboard)
        {
            return Ok(this._context.CreateNewKeyboard(keyboard)); 
        }
    }
}
