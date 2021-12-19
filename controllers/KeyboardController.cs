using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeebClack.API.controllers
{
    [Route("api/keyboard")]
    [ApiController]
    public class KeyboardController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetAllKeyboards()
        {
            return new JsonResult(
                new List<object>()
                {
                    new {id = 1, Name= "Ducky"},
                    new {id = 2, Name= "Vortex"}
                });
        }

        [HttpGet("{id:int}")]
        public JsonResult GetOneKeyboard(int id)
        {
            return new JsonResult(
                new List<object>()
                {
                    new {id= 0, Name=id},
                    new {id= 1, Name= 1},
                    new {id= 2, Name= 2}
                });
        }
    }
}
