using System;
using System.Collections.Generic;
using System.Linq;
using simple_blog.Domain.Post.Model;
using simple_blog.Infrastructure.Persistance.Database;
using simple_blog.Infrastructure.Persistance.Database.Postgresql;

namespace simple_blog.Infrastructure.Domain.Posts
{
	public class NpgsqlPostRepository: IPostRepository
	{
        public static int MAX_ELEMENTS_PER_PAGE = 10;

        private readonly SimpleBlogDatabase context;

        public NpgsqlPostRepository(SimpleBlogDatabase _context)
        {
            context = _context;
        }

        /// <summary>
        /// Adds a new Post
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Post Add(Post post)
        {
            PostgresqlPost entity = FromDomain(post);
            context.Post.Add(entity);
            context.SaveChanges();

            return ToDomain(entity);
        }

        /// <summary>
        /// Deletes a Post
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(Post post)
        {
            PostgresqlPost entity = FromDomain(post);

            context.Post.Remove(entity);
            context.SaveChanges();
        }

        /// <summary>
        /// Gets a Post by its identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Post GetById(int id)
        {
            return ToDomain(context.Post.Find(id));
        }

        /// <summary>
        /// Get the total Posts
        /// </summary>
        /// <returns></returns>
        public int GetTotalElements()
        {
            return context.Post.Count();
        }

        /// <summary>
        /// Gets a Post list. Title filter is optional.
        /// </summary>
        /// <param name="titleFilter"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<Post> List(string titleFilter, int page)
        {
            IQueryable<PostgresqlPost> query = context.Post.AsQueryable();

            if (!String.IsNullOrEmpty(titleFilter))
            {
                query = query.Where(post => post.Title != null && post.Title.ToLower().Contains(titleFilter.ToLower()));
            }

            int skip = (page - 1) * MAX_ELEMENTS_PER_PAGE;

            return query.Skip(skip).Take(MAX_ELEMENTS_PER_PAGE).OrderByDescending(post => post.CreatedAt).Select(entity => ToDomain(entity)).ToList();
        }

        /// <summary>
        /// Updates a Post
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Post Update(Post post)
        {
            PostgresqlPost entity = FromDomain(post);

            context.Post.Update(entity);
            context.SaveChanges();

            return ToDomain(entity);
        }

        private PostgresqlPost FromDomain(Post post)
        {
            context.ChangeTracker.Clear();

            return new PostgresqlPost(
                post.Id,
                post.Title,
                post.Body,
                post.IsDraft,
                post.CreatedAt,
                post.UpdatedAt,
                post.DeletedAt
                );
        }

        private Post ToDomain(PostgresqlPost entity)
        {
            context.ChangeTracker.Clear();

            return new Post(entity.Id, entity.Title, entity.Body, entity.IsDraft, entity.CreatedAt);
        }
    }
}

