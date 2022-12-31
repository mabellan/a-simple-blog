using System;
using System.Collections.Generic;
using System.Reflection;

namespace simple_blog.Infrastructure.Delivery.Configuration
{
    public interface IQuery<TResult>
    {
    }

    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }

    public class QueryBus
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TResult Execute<TResult>(IQuery<TResult> query)
        {
            Type queryType = query.GetType();
            Type handlerType = typeof(IQueryHandler<,>).MakeGenericType(queryType, typeof(TResult));
            object handler = _serviceProvider.GetService(handlerType);

            MethodInfo method = handlerType.GetMethod("Handle");
            return (TResult)method.Invoke(handler, new object[] { query });
        }
    }
}

