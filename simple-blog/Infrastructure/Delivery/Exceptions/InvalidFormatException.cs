using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simple_blog.Infrastructure.Delivery.Exceptions
{
    public class InvalidFormatException: Exception
    {
        public InvalidFormatException()
        {
        }

        public InvalidFormatException(string message)
            : base(message)
        {
        }

        public InvalidFormatException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
