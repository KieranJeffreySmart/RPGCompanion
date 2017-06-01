namespace RPGCompanion.Application.Domain
{
    using Mediator;

    public class DomainResponse: IResponse
    {

    }

    public class DomainResponse<TResult>: IResponse<TResult>
    {
        public TResult Result { get; set; }
    }

    public class FailedResponse : DomainResponse
    {
        
    }

    public class FailedResponse<TResult> : DomainResponse<TResult>
    {

    }

    public class SuccessResponse : DomainResponse
    {

    }

    public class SuccessResponse<TResult> : DomainResponse<TResult>
    {

    }
}