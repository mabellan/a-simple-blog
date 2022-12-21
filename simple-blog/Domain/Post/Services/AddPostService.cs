using System;

namespace simple_blog.Domain.Post.Services
{
	public class AddPostService
	{
        private readonly Post.Model.IPostRepository postRepository;


        public AddPostService(Post.Model.IPostRepository _postRepository)
		{
            postRepository = _postRepository;
        }


        public void Execute(Post.Model.Post post)
        {
            postRepository.Add(post);
        }

    }
}

