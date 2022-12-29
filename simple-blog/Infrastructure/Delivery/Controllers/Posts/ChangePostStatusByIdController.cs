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
    public class ChangePostStatusByIdController : BaseController
    {
        private readonly ICommandBus _commandBus;

        public ChangePostStatusByIdController(IPostRepository postRepository, ICommandBus commandBus, QueryBus queryBus)
        {
            _commandBus = commandBus;
            _commandBus.RegisterHandler(new SetPostIsDraftCommandHandler(postRepository, queryBus));
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> ChangeStatus([FromRoute] int id, [FromBody] StatusRequest statusRequest)
        {
            try
            {
                _commandBus.Send(new SetPostIsDraftCommand(id, statusRequest.IsDraft));
                return Ok();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}

