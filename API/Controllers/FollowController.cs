using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Followers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class FollowController : BaseApiController
    {
        [HttpPost("{username}")]
        public async Task<IActionResult> Follow(string username, string currentUsername)
        {
            return HandleResult(
                await Mediator.Send(
                    new FollowToggle.Command
                    {
                        TargetUsername = username,
                        CurrentUsername = currentUsername
                    }
                )
            );
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetFollowings(string username, string predicate)
        {
            return HandleResult(await Mediator.Send(new List.Query { Predicate = predicate, Username = username }));
        }
    }
}