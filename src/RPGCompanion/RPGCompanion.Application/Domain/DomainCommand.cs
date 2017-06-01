namespace RPGCompanion.Application.Domain
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