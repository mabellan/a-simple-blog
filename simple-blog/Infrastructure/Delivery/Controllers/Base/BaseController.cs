using System;
using Microsoft.AspNetCore.Mvc;
using simple_blog.Infrastructure.Delivery.Configuration;
using simple_blog.Infrastructure.Delivery.Exceptions;

namespace simple_blog.Infrastructure.Delivery.Controllers.Base
{
    public abstract class BaseController : ControllerBase
    {
        protected ActionResult HandleException(Exception e)
        {
            if (e is NotFoundException)
                return NotFound(e.Message);
            if (e is ConflictException)
                return Conflict(e.Message);
            if (e is InvalidFormatException)
                return BadRequest(e.Message);

            return StatusCode(500, e.Message + ": " + e.InnerException);
        }
    }
}

