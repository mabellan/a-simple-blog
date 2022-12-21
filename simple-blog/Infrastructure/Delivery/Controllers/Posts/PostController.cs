using System;
using Microsoft.AspNetCore.Mvc;
using simple_blog.Services;
using System.Threading.Tasks;
using simple_blog.Infrastructure.Delivery.Controllers.Base;
using simple_blog.Infrastructure.Delivery.Models.Posts;

namespace simple_blog.Infrastructure.Delivery.Controllers.Posts
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : BaseController
    {
        private readonly PostsService postsService;

        public PostsController(PostsService _postsService)
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

