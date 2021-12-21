﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KeebClack.API.models;


namespace KeebClack.API.controllers
{
    [Route("api/userinmemory")]
    [ApiController]
    public class UserInMemoryController : ControllerBase
    {
        private readonly ILogger<UserInMemoryController> _logger;
        private readonly UserDbContext _context;

        public UserInMemoryController(ILogger<UserInMemoryController> logger, UserDbContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            List<User> users = this._context.getUsers();
            return Ok(users);
        }
    }
}