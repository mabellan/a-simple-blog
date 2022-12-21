using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using simple_blog.Domain.Post.Model;

namespace simple_blog.Infrastructure.Delivery.Models.Posts
{
    public class PostResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsDraft { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public PostResponse(Post post)
        {
            if (post != null)
            {
                Id = post.Id;
                Title = post.Title;
                Body = post.Body;
                IsDraft = post.IsDraft;
                CreatedAt = post.CreatedAt;
                UpdatedAt = post.UpdatedAt;
            }
        }
    }
}
