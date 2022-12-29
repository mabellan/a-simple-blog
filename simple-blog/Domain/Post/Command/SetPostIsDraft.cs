using System;
using simple_blog.Domain.Post.Model;
using simple_blog.Domain.Post.Query;
using simple_blog.Infrastructure.Delivery.Configuration;
using aPost = simple_blog.Domain.Post.Model.Post;

namespace simple_blog.Domain.Post.Command
{
    public class SetPostIsDraftCommand: ICommand
    {
        public int Id { get; set; }
        public bool IsDraft { get; set; }

        public SetPostIsDraftCommand(int id, bool isDraft)
        {
            Id = id;
            IsDraft = isDraft;
        }
    }

    public class SetPostIsDraftCommandHandler: ICommandHandler<SetPostIsDraftCommand>
    {
        private readonly IPostRepository _postRepository;
        private readonly QueryBus _queryBus;

        public SetPostIsDraftCommandHandler(IPostRepository postRepository, QueryBus queryBus)
        {
            _postRepository = postRepository;
            _queryBus = queryBus;
        }

        public void Handle(SetPostIsDraftCommand command)
        {
            aPost postToUpdate = _queryBus.Execute<aPost>(new GetPostByIdQuery(command.Id));

            if (postToUpdate == null)
            {
                throw new Exception($"No Post found with id: {command.Id}");
            }

            postToUpdate.IsDraft = command.IsDraft;
            postToUpdate.UpdatedAt = DateTime.Now;

            _postRepository.Update(postToUpdate);
        }
    }
}

