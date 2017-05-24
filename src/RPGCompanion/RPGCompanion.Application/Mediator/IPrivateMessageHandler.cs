namespace RPGCompanion.Application.Mediator
{
    using System.Threading.Tasks;

    public interface IPrivateMessageHandler<in TMessage, TResult> where TMessage : IPrivateMessage<TResult>
    {
        Task<TResult> Handle(TMessage command);
    }

    public interface IPrivateMessageHandler<in TMessage> where TMessage : IPrivateMessage
    {
        Task Handle(TMessage command);
    }
}