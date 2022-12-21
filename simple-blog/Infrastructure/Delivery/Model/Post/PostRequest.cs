using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace simple_blog.Infrastructure.Delivery.Models.Posts
{
    public class PostRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public bool IsDraft { get; set; }

        public bool IsValid()
        {
            return !String.IsNullOrEmpty(Title) &&
                    !String.IsNullOrEmpty(Body);
        }
    }

    public class StatusRequest
    {
        [Required]
        public bool IsDraft { get; set; }
    }
}
