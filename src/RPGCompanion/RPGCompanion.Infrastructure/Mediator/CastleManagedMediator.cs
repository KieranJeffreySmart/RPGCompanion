namespace RPGCompanion.Infrastructure.Mediator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Mediator;
    using Application.Response;

    public class CastleManagedMediator: IManagedMediator
    {
        private readonly SingleHandlerFactory _singleHandlerFactory;
        private readonly MultipleHandlerFactory _multipleHandlerFactory;

        public CastleManagedMediator(SingleHandlerFactory singleHandlerFactory, MultipleHandlerFactory multipleHandlerFactory)
        {
            _singleHandlerFactory = singleHandlerFactory;
            _multipleHandlerFactory = multipleHandlerFactory;
        }

        public async Task<IResponse<TResult>> Send<TResult>(IPrivateMessage<TResult> message)
        {
            var handlerType = typeof(IPrivateMessageHandler<,>);
            var specificHandlerType = handlerType.MakeGenericType(message.GetType(), typeof(TResult));
            var handler = _singleHandlerFactory(specificHandlerType);
            if (handler == null)
            {
                return new FailedResponse<TResult>();
            }
            var method = specificHandlerType.GetMethod("Handle");

            return new SuccessResponse<TResult>{ Result = await (Task<TResult>) method.Invoke(handler, new object[] { message }) };
        }

        public async Task<IResponse> Send(IPrivateMessage message)
        {
            var handlerType = typeof(IPrivateMessageHandler<>);
            var specificHandlerType = handlerType.MakeGenericType(message.GetType());
            var handler = _singleHandlerFactory(specificHandlerType);

            if (handler == null)
            {
                return new FailedResponse();
            }
            var method = specificHandlerType.GetMethod("Handle");
            await (Task)method.Invoke(handler, new object[] { message });
            return new SuccessResponse();
        }

        public async Task<IResponse> Publish<TNotification>(TNotification notification) where TNotification : IPublicMessage
        {
            var handlerType = typeof(IPublicMessageHandler<>);
            var specificHandlerType = handlerType.MakeGenericType(notification.GetType());
            var handlers = _multipleHandlerFactory(specificHandlerType);

            if (handlers == null)
            {
                return new FailedResponse();
            }

            var handlerList = handlers.ToList();
            if (!handlerList.Any())
            {
                return new FailedResponse();
            }

            foreach (var publicMessageHandler in handlerList)
            {
                var method = specificHandlerType.GetMethod("Handle");
                await (Task)method.Invoke(publicMessageHandler, new object[] { notification });
            }

            return new SuccessResponse();
        }
    }

    public delegate object SingleHandlerFactory(Type handlerType);

    public delegate IEnumerable<object> MultipleHandlerFactory(Type handlerType);
}
