using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API.Controllers
{
    [Route("[controller]")]
    public class AppUsersController : BaseApiController
    {
        private readonly ILogger<AppUsersController> _logger;
        private readonly DataContext _context;

        public AppUsersController(ILogger<AppUsersController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AppUser>>> GetUsers()
        {
            return await _context.AppUsers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(Guid id)
        {
            return await _context.AppUsers.FindAsync(id);
        }
    }
}