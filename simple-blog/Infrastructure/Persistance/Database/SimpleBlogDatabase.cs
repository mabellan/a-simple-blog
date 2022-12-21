using System;
using Microsoft.EntityFrameworkCore;
using simple_blog.Infrastructure.Persistance.Database.Postgresql;

namespace simple_blog.Infrastructure.Persistance.Database
{
    public class SimpleBlogDatabase : DbContext
    {
        public DbSet<PostgresqlPost> Post { get; set; }

        public SimpleBlogDatabase(DbContextOptions<SimpleBlogDatabase> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostgresqlPost>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Title).HasColumnType("VARCHAR(MAX)");
                entity.Property(e => e.Body).HasColumnType("VARCHAR(MAX)");
                entity.Property(e => e.IsDraft).HasColumnType("BOOLEAN");

                entity.Property(e => e.CreatedAt).HasColumnType("DATETIME");
                entity.Property(e => e.UpdatedAt).HasColumnType("DATETIME");

                entity.HasQueryFilter(p => p.DeletedAt == null);
            });
        }
    }
}

