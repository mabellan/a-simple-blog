using System;
using simple_blog.Domain.Post.Command;
using simple_blog.Domain.Post.Model;
using simple_blog.Infrastructure.Delivery.Configuration;
using aPost = simple_blog.Domain.Post.Model.Post;

namespace simple_blog.Domain.Post.Query
{
	public class GetPostByIdQuery: IQuery<aPost>
	{
        public int Id { get; set; }

        public GetPostByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetPostByIdQueryHandler : IQueryHandler<GetPostByIdQuery, aPost>
    {
        private readonly IPostRepository _postRepository;

        public GetPostByIdQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public aPost Handle(GetPostByIdQuery query)
        {
            return _postRepository.GetById(query.Id);
        }
    }
}

