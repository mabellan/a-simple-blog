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
    public class UpdatePostByIdController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly QueryBus _queryBus;

        public UpdatePostByIdController(ICommandBus commandBus, IPostRepository postRepository, QueryBus queryBus)
        {
            _commandBus = commandBus;
            _commandBus.RegisterHandler(new UpdatePostCommandHandler(postRepository, queryBus));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PostRequest postRequest)
        {
            try
            {
                _commandBus.Send(new UpdatePostCommand(id, postRequest.Title, postRequest.Body));
                return NoContent();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

    }
}

