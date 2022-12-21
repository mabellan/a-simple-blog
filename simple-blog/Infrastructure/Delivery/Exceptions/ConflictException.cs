using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simple_blog.Infrastructure.Delivery.Exceptions
{
    public class ConflictException: Exception
    {
        public ConflictException()
        {
        }

        public ConflictException(string message)
            : base(message)
        {
        }

        public ConflictException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
