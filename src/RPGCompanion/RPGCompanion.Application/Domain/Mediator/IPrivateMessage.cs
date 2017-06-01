namespace RPGCompanion.Application.Domain.Mediator
{
    public interface IPrivateMessage
    {
    }

    public interface IPrivateMessage<TResult>
    {
        TResult Result { get; set; }
    }
}