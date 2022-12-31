using System;
using simple_blog.Domain.Post.Model;
using aPost = simple_blog.Domain.Post.Model.Post;
using simple_blog.Infrastructure.Delivery.Configuration;
using simple_blog.Domain.Post.Query;

namespace simple_blog.Domain.Post.Command
{
    public class UpdatePostCommand : ICommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Body Body { get; set; }

        public UpdatePostCommand(int id, string title, string body)
        {
            Id = id;
            Title = title;
            Body = new Body(body);
        }
    }

    public class UpdatePostCommandHandler : ICommandHandler<UpdatePostCommand>
    {
        private readonly IPostRepository _postRepository;
        private readonly QueryBus _queryBus;

        public UpdatePostCommandHandler(IPostRepository postRepository, QueryBus queryBus)
        {
            _postRepository = postRepository;
            _queryBus = queryBus;
        }

        public void Handle(UpdatePostCommand command)
        {
            aPost postToUpdate = _queryBus.Execute<aPost>(new GetPostByIdQuery(command.Id));

            if (postToUpdate == null)
            {
                throw new Exception($"No Post found with id: {command.Id}");
            }

            postToUpdate.Title = command.Title;
            postToUpdate.Body = command.Body.aBody;
            postToUpdate.UpdatedAt = DateTime.Now;

            _postRepository.Update(postToUpdate);
        }
    }
}
