using System;
using simple_blog.Domain.Post.Model;
using simple_blog.Infrastructure.Delivery.Configuration;

namespace simple_blog.Domain.Post.Command
{
    public class AddPostCommand: ICommand
    {
        public string Title { get; set; }
        public Body Body { get; set; }

        public AddPostCommand(string title, string body)
        {
            Title = title;
            Body = new Body(body);
        }
    }

    public class AddPostCommandHandler: ICommandHandler<AddPostCommand>
    {
        private readonly IPostRepository _postRepository;

        public AddPostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public void Handle(AddPostCommand command)
        {
            _postRepository.Add(new Model.Post(0, command.Title, command.Body.aBody, true, DateTime.Now));
        }
    }
}

