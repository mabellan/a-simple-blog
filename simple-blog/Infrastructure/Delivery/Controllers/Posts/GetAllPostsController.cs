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
    public class GetAllPostsController : BaseController
    {
        private readonly QueryBus _queryBus;

        public GetAllPostsController(QueryBus queryBus)
        {
            _queryBus = queryBus;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] string titleFilter, int? page)
        {
            try
            {
                int aPage = page.HasValue ? page.Value : 1;

                return Ok(_queryBus.Execute(new GetPostsQuery(titleFilter, aPage)));
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}

