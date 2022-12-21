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
    public class UpdatePostByIdController : BaseController
    {
        private readonly PostsService postsService;

        public UpdatePostByIdController(PostsService _postsService)
        {
            postsService = _postsService;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PostRequest postRequest)
        {
            try
            {
                return Ok(postsService.Update(id, postRequest));
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

    }
}

