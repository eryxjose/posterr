using System;
using System.Threading.Tasks;
using Application.Core;
using Application.Posts;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PostsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetPosts([FromQuery] FilterParams param, 
            [FromQuery] PagingParams pagingParams)
        {
            return HandlePagedResult(await Mediator.Send(
                new List.Query { Params = param, PagingParams = pagingParams }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(Post post)
        {
            return Ok(await Mediator.Send(new Create.Command { Post = post }));
        }
     }
}