using System;
using System.Threading.Tasks;
using Application.AppUsers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AppUsersController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetUsers(string currentUsername)
        {
            return HandleResult(await Mediator.Send(new List.Query { CurrentUsername = currentUsername }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }
    }
}