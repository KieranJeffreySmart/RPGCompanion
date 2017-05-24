namespace RPGCompanion.Application.Mediator
{
    public interface IPrivateMessage
    {
    }

    public interface IPrivateMessage<TResult>
    {
        TResult Result { get; set; }
    }
}