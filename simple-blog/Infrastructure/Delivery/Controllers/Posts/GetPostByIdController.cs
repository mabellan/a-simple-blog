using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using simple_blog.Infrastructure.Delivery.Controllers.Base;
using simple_blog.Services;

namespace simple_blog.Infrastructure.Delivery.Controllers.Posts
{
    [Route("api/posts")]
    public class GetPostByIdController : BaseController
    {
        private readonly PostsService postsService;

        public GetPostByIdController(PostsService _postsService)
        {
            postsService = _postsService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                return Ok(postsService.Get(id));
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}

