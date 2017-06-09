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
    using Application.Domain;
    using Application.Domain.Mediator;
    using Application.Narrative;
    using Domain.Model.Narrative;

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
            var response = await _mediator.Send(new ViewStories());

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