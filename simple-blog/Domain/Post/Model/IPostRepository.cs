using System;
using System.Collections.Generic;

namespace simple_blog.Domain.Post.Model
{
	public interface IPostRepository
	{
        Post GetById(int id);
        List<Post> List(string titleFilter, int page);
        Post Add(Post post);
        Post Update(Post post);
        void Delete(Post post);
        int GetTotalElements();
    }
}

