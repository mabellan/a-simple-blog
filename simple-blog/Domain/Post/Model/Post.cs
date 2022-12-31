using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace simple_blog.Domain.Post.Model
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public bool IsDraft { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public Post(int id, string title, string body, bool isDraft, DateTime createdAt)
        {
            Id = id;
            Title = title;
            Body = body;
            IsDraft = isDraft;
            CreatedAt = createdAt;
        }
    }
}

