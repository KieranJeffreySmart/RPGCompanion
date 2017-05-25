namespace RPGCompanion.Api
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Results;
    using Application.Commands;
    using Application.Mediator;
    using Application.Queries;
    using Application.Response;
    using Domain.Model.Context;

    public class ContextController: ApiController
    {
        private readonly IManagedMediator _mediator;

        public ContextController(IManagedMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("api/v1/ContextCollection/{id}")]
        public async Task<IHttpActionResult> Get(Guid? id)
        {
            if (!id.HasValue)
            {
                return new ResponseMessageResult(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            }

            var response = await _mediator.Send(new GetContextCollection { Id = id.Value }); // new Guid(id) });

            if (response is FailedResponse<ContextCollection>)
            {
                return new ResponseMessageResult(new HttpResponseMessage { StatusCode = HttpStatusCode.InternalServerError });
            }

            var message = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<ContextCollection>(response.Result, new JsonMediaTypeFormatter())
            };

            return ResponseMessage(message);
        }

        [HttpPost]
        [Route("api/v1/ContextCollection")]
        public async Task<IHttpActionResult> Post([FromBody] NewContextCollection newMessage)
        {
            if (newMessage == null)
            {
                return new ResponseMessageResult(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            }

            var response = await _mediator.Send(newMessage);

            if (response is FailedResponse<Guid>)
            {
                return new ResponseMessageResult(new HttpResponseMessage { StatusCode = HttpStatusCode.InternalServerError });
            }

            return Created($"{Request.RequestUri.ToString().TrimEnd(new[] { '/' })}/{response.Result}", string.Empty);
        }
    }
}