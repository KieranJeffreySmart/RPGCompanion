namespace RPGCompanion.Application.Domain.Mediator
{
    public interface IResponse
    {
        
    }

    public interface IResponse<TResult>
    {
        TResult Result { get; set; }
    }
}