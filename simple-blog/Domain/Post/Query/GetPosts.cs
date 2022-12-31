using System;
using System.Collections.Generic;
using simple_blog.Domain.Post.Model;
using simple_blog.Infrastructure.Delivery.Configuration;
using aPost = simple_blog.Domain.Post.Model.Post;

namespace simple_blog.Domain.Post.Query
{
    public class GetPostsQuery: IQuery<List<aPost>>
    {
        public string TitleFilter { get; set; }
        public int Page { get; set; }

        public GetPostsQuery(string titleFilter, int page)
        {
            TitleFilter = titleFilter;
            Page = page;
        }
    }

    public class GetPostsQueryHandler: IQueryHandler<GetPostsQuery, List<aPost>>
    {
        private readonly IPostRepository _postRepository;

        public GetPostsQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public List<aPost> Handle(GetPostsQuery query)
        {
            return _postRepository.List(query.TitleFilter, query.Page);
        }
    }
}

