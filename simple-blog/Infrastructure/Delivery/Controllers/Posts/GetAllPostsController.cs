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
    public class GetAllPostsController : BaseController
    {
        private readonly PostsService postsService;

        public GetAllPostsController(PostsService _postsService)
        {
            postsService = _postsService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] string titleFilter, int? page)
        {
            try
            {
                return Ok(postsService.GetList(titleFilter, page));
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}

