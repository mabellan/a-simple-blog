using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using simple_blog.Infrastructure.Delivery.Controllers.Base;
using simple_blog.Infrastructure.Delivery.Models.Posts;
using simple_blog.Services;

namespace simple_blog.Infrastructure.Delivery.Controllers.Posts
{
    [Route("api/posts")]
    public class AddPostController : BaseController
    {
        private readonly PostsService postsService;

        public AddPostController(PostsService _postsService)
        {
            postsService = _postsService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostRequest postRequest)
        {
            try
            {
                return Ok(postsService.Add(postRequest));
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}

