namespace RPGCompanion.Application.Queries
{
    using Mediator;

    public class DomainQuery<TResult> : IPrivateMessage<TResult>
    {
        public TResult Result { get; set; }
    }
}