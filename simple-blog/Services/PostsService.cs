using simple_blog.Domain.Post;
using simple_blog.Infrastructure.Delivery.Exceptions;
using simple_blog.Infrastructure.Delivery.Model;
using simple_blog.Domain.Post.Model;
using System;
using System.Collections.Generic;
using simple_blog.Infrastructure.Delivery.Models.Posts;

namespace simple_blog.Services
{
    /// <summary>
    /// Service with all business logic about posts.
    /// </summary>
    public class PostsService
    {
        private readonly IPostRepository baseRepository;

        public PostsService(IPostRepository _baseRepository)
        {
            baseRepository = _baseRepository;
        }
    
        /// <summary>
        /// Gets a paginated list with posts. Title filter is available.
        /// </summary>
        /// <param name="titleFilter"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public PaginationResponse<PostResponse> GetList(string titleFilter, int? page)
        {
            if (!page.HasValue || page.Value < 1)
            {
                page = 1;
            }

            int totalElements = baseRepository.GetTotalElements();

            return new PaginationResponse<PostResponse>(baseRepository.List(titleFilter, page.Value).ConvertAll(post => new PostResponse(post)), totalElements);
        }

        /// <summary>
        /// Removes a Post if it exist as a draft. If the post is published the delete operation is forbidden.
        /// </summary>
        /// <param name="postId"></param>
        public void RemoveDraft(int postId)
        {
            Post post = baseRepository.GetById(postId);

            if (post == null)
            {
                throw new NotFoundException($"No post found with ID {postId}");
            }

            if (!post.IsDraft)
            {
                throw new ConflictException("You cannot delete a post when published");
            }

            baseRepository.Delete(post);
        }

        /// <summary>
        /// Updates the field <see cref="Post.IsDraft"/>
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="isDraft"></param>
        /// <returns></returns>
        public PostResponse UpdateIsDraft(int postId, bool isDraft)
        {
            Post post = baseRepository.GetById(postId);

            if (post == null)
            {
                throw new NotFoundException($"No post found with ID {postId}");
            }

            post.IsDraft = isDraft;

            return new PostResponse(baseRepository.Update(post));
        }
    }
}
