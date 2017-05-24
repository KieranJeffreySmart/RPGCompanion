namespace RPGCompanion.Application.Commands
{
    using Mediator;

    public class DomainCommand: IPrivateMessage
    {

    }

    public class DomainCommand<TResult> : IPrivateMessage<TResult>
    {
        public TResult Result { get; set; }
    }
}