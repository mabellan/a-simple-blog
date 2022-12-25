using System;
using System.Collections.Generic;

namespace simple_blog.Infrastructure.Delivery.Configuration
{
    public interface ICommand
    {
    }

    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }

    public interface ICommandBus
    {
        void RegisterHandler<T>(ICommandHandler<T> handler) where T : ICommand;
        void Send<T>(T command) where T : ICommand;
    }

    public class CommandBus: ICommandBus
    {
        private readonly Dictionary<Type, object> _handlers = new Dictionary<Type, object>();

        public void RegisterHandler<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand
        {
            _handlers[typeof(TCommand)] = handler;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            object handler;
            if (_handlers.TryGetValue(typeof(TCommand), out handler))
            {
                ((ICommandHandler<TCommand>)handler).Handle(command);
            }
            else
            {
                throw new InvalidOperationException("No handler registered for command of type " + typeof(TCommand).Name);
            }
        }
    }
}


