namespace RPGCompanion.Application.Domain
{
    using Mediator;

    public class DomainQuery<TResult> : IPrivateMessage<TResult>
    {
        public TResult Result { get; set; }
    }
}