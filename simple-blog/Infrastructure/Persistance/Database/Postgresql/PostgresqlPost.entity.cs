using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace simple_blog.Infrastructure.Persistance.Database.Postgresql
{
    [Table("post")]
    public class PostgresqlPost
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("body")]
        public string Body { get; set; }

        [Column("is_draft")]
        public bool IsDraft { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        public PostgresqlPost(int id, string title, string body, bool isDraft, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt)
        {
            Id = id;
            Title = title;
            Body = body;
            IsDraft = isDraft;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            DeletedAt = deletedAt;
        }
    }
}

