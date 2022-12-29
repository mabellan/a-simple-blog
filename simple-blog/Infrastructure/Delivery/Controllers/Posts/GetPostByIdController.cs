using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using simple_blog.Domain.Post.Query;
using simple_blog.Infrastructure.Delivery.Configuration;
using simple_blog.Infrastructure.Delivery.Controllers.Base;

namespace simple_blog.Infrastructure.Delivery.Controllers.Posts
{
    [Route("api/posts")]
    public class GetPostByIdController : BaseController
    {
        private readonly QueryBus _queryBus;

        public GetPostByIdController(QueryBus queryBus)
        {
            _queryBus = queryBus;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                return Ok(_queryBus.Execute(new GetPostByIdQuery(id)));
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}

