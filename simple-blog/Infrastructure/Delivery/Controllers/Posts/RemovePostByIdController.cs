using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using simple_blog.Infrastructure.Delivery.Controllers.Base;
using simple_blog.Services;

namespace simple_blog.Infrastructure.Delivery.Controllers.Posts
{
    public class RemovePostByIdController : BaseController
    {
        private readonly PostsService postsService;

        public RemovePostByIdController(PostsService _postsService)
        {
            postsService = _postsService;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                postsService.RemoveDraft(id);
                return Ok();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}

