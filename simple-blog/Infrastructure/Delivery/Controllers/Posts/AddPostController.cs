using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using simple_blog.Domain.Post.Command;
using simple_blog.Domain.Post.Model;
using simple_blog.Infrastructure.Delivery.Configuration;
using simple_blog.Infrastructure.Delivery.Controllers.Base;
using simple_blog.Infrastructure.Delivery.Models.Posts;

namespace simple_blog.Infrastructure.Delivery.Controllers.Posts
{
    [Route("api/posts")]
    public class AddPostController : BaseController
    {
        private readonly ICommandBus _commandBus;

        public AddPostController(ICommandBus commandBus, IPostRepository postRepository)
        {
            _commandBus = commandBus;
            _commandBus.RegisterHandler(new AddPostCommandHandler(postRepository));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostRequest postRequest)
        {
            try
            {
                _commandBus.Send(new AddPostCommand(postRequest.Title, postRequest.Body));
                return Ok();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}

