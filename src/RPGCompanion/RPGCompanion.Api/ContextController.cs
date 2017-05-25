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
        [Route("api/v1/ContextCollections")]
        public async Task<IHttpActionResult> Get()
        {
            var response = await _mediator.Send(new GetContextCollections());

            if (response is FailedResponse<IEnumerable<ContextCollection>>)
            {
                return new ResponseMessageResult(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound });
            }

            var message = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<IEnumerable<ContextCollection>>(response.Result, new JsonMediaTypeFormatter())
            };

            return ResponseMessage(message);
        }

        [HttpGet]
        [Route("api/v1/ContextCollections/{id}")]
        public async Task<IHttpActionResult> Get(Guid? id)
        {
            if (!id.HasValue)
            {
                return new ResponseMessageResult(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound });
            }

            var response = await _mediator.Send(new GetContextCollection { Id = id.Value });

            if (response is FailedResponse<ContextCollection>)
            {
                return new ResponseMessageResult(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound });
            }

            var message = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<ContextCollection>(response.Result, new JsonMediaTypeFormatter())
            };

            return ResponseMessage(message);
        }

        [HttpPost]
        [Route("api/v1/ContextCollections")]
        public async Task<IHttpActionResult> Post([FromBody] NewContextCollection newMessage)
        {
            if (newMessage == null)
            {
                return new ResponseMessageResult(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound });
            }

            var response = await _mediator.Send(newMessage);

            if (response is FailedResponse<Guid>)
            {
                return new ResponseMessageResult(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound });
            }

            return Created($"{Request.RequestUri.ToString().TrimEnd(new[] { '/' })}/{response.Result}", string.Empty);
        }

        [HttpGet]
        [Route("api/v1/ContextCollections/{collectionId}/Contexts/{id}")]
        public async Task<IHttpActionResult> GetContext(Guid? collectionId, Guid? id)
        {
            if (!collectionId.HasValue || !id.HasValue)
            {
                return new ResponseMessageResult(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound });
            }

            var response = await _mediator.Send(new GetContext { CollectionId = collectionId.Value, ContextId = id.Value });

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

        [HttpPost]
        [Route("api/v1/ContextCollections/{collectionId}/Contexts")]
        public async Task<IHttpActionResult> PostContext(Guid? collectionId, [FromBody] NewContext newMessage)
        {
            if (!collectionId.HasValue || newMessage == null)
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