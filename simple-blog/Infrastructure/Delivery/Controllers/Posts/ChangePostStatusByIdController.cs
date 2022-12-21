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
    public class ChangePostStatusByIdController : BaseController
    {
        private readonly PostsService postsService;

        public ChangePostStatusByIdController(PostsService _postsService)
        {
            postsService = _postsService;
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> ChangeStatus([FromRoute] int id, [FromBody] StatusRequest statusRequest)
        {
            try
            {
                return Ok(postsService.UpdateIsDraft(id, statusRequest.IsDraft));
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}

