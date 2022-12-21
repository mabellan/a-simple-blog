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
        /// Adds a new Post.
        /// </summary>
        /// <param name="postsRequest"></param>
        /// <returns></returns>
        public PostResponse Add(PostRequest postsRequest)
        {
            if (!postsRequest.IsValid())
            {
                throw new InvalidFormatException("Fields Title, Body and IsDraft are mandatory");
            }

            Post post = new Post(postsRequest.Title, postsRequest.Body);

            return new PostResponse(baseRepository.Add(post));
        }

        /// <summary>
        /// Updates an existing Post. If the post does not exist an exception is thrown.
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="postRequest"></param>
        /// <returns></returns>
        public PostResponse Update(int postId, PostRequest postRequest)
        {
            if (!postRequest.IsValid())
            {
                throw new InvalidFormatException("Fields Title, Body and IsDraft are mandatory");
            }

            Post post = GetById(postId);

            post.Title = postRequest.Title;
            post.Body = postRequest.Body;
            post.IsDraft = postRequest.IsDraft;
            post.UpdatedAt = DateTime.Now;

            return new PostResponse(baseRepository.Update(post));
        }

        /// <summary>
        /// Gets a Post by its identifier.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        private Post GetById(int postId)
        {
            Post post = baseRepository.GetById(postId);

            if (post == null)
            {
                throw new NotFoundException($"No post found with ID {postId}");
            }

            return post;
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
        /// Gets a Post by its identifier.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public PostResponse Get(int postId)
        {
            return new PostResponse(GetById(postId));
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
