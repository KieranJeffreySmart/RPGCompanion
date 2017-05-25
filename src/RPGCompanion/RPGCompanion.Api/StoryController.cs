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
    using Domain.Model.Story;

    public class StoryController: ApiController
    {
        private readonly IManagedMediator _mediator;

        public StoryController(IManagedMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        [Route("api/v1/Stories")]
        public async Task<IHttpActionResult> Get()
        {
            var response = await _mediator.Send(new GetStories());

            if (response is FailedResponse<IEnumerable<Story>>)
            {
                return new ResponseMessageResult(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound });
            }

            var message = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<IEnumerable<Story>>(response.Result, new JsonMediaTypeFormatter())
            };

            return ResponseMessage(message);
        }

        [HttpGet]
        [Route("api/v1/Stories/{id}")]
        public async Task<IHttpActionResult> Get(Guid? id)
        {
            if (!id.HasValue)
            {
                return new ResponseMessageResult(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound });
            }

            var response = await _mediator.Send(new GetStory { Id = id.Value });

            if (response is FailedResponse<Story>)
            {
                return new ResponseMessageResult(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound });
            }

            var message = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<Story>(response.Result, new JsonMediaTypeFormatter())
            };

            return ResponseMessage(message);
        }

        [HttpPost]
        [Route("api/v1/Stories")]
        public async Task<IHttpActionResult> Post([FromBody] NewStory newMessage)
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
    }
}