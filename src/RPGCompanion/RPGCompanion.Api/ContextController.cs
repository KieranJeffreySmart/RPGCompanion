namespace RPGCompanion.Api
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Results;
    using Application.Context;
    using Application.Domain;
    using Application.Domain.Mediator;
    using Domain.Model.Context;

    public class ContextController: ApiController
    {
        private readonly IManagedMediator _mediator;

        public ContextController(IManagedMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("api/v1/Contexts/{id}")]
        public async Task<IHttpActionResult> GetContext(Guid? id)
        {
            if (!id.HasValue)
            {
                return new ResponseMessageResult(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound });
            }

            var response = await _mediator.Send(new ReadContext { ContextId = id.Value });

            if (response is FailedResponse<Context>)
            {
                return new ResponseMessageResult(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound });
            }

            var message = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<Context>(response.Result, new JsonMediaTypeFormatter())
            };

            return ResponseMessage(message);
        }

        [HttpGet]
        [Route("api/v1/Contexts")]
        public async Task<IHttpActionResult> GetContexts()
        {
            var response = await _mediator.Send(new ViewContexts());

            if (response is FailedResponse<IEnumerable<Context>>)
            {
                return new ResponseMessageResult(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound });
            }

            var message = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<IEnumerable<Context>>(response.Result, new JsonMediaTypeFormatter())
            };

            return ResponseMessage(message);
        }

        [HttpPost]
        [Route("api/v1/Contexts")]
        public async Task<IHttpActionResult> PostContext([FromBody] CreateContext newMessage)
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