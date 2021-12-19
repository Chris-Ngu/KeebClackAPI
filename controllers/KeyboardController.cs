using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeebClack.API.controllers
{
    [ApiController]
    public class KeyboardController : ControllerBase
    {
        [HttpGet("api/keyboards")]
        public JsonResult GetKeyboards()
        {
            return new JsonResult(
                new List<object>()
                {
                    new {id = 1, Name= "Ducky"},
                    new {id = 2, Name= "Vortex"}
                });
        }
    }
}
