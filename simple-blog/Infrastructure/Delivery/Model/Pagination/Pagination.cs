using System;
using System.Collections.Generic;

namespace simple_blog.Infrastructure.Delivery.Model
{
    public class PaginationResponse<T>
    {

        public int TotalElements { get; set; }
        public List<T> Elements { get; set; }

        public PaginationResponse(List<T> response, int totalElements)
        {
            TotalElements = totalElements;
            Elements = response;
        }
    }
}

