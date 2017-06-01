namespace RPGCompanion.Application.Domain.Mediator
{
    using System.Threading.Tasks;

    public interface IManagedMediator
    {
        Task<IResponse<TResult>> Send<TResult>(IPrivateMessage<TResult> message);

        Task<IResponse> Send(IPrivateMessage message);

        Task<IResponse> Publish<TNotification>(TNotification notification) where TNotification : IPublicMessage;
    }
}