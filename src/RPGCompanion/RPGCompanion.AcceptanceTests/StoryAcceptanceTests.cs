namespace RPGCompanion.AcceptanceTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using Api.IoC;
    using Application.Commands;
    using Application.Mediator;
    using Application.Queries;
    using Domain.Model.Context;
    using Domain.Model.Values;
    using FluentAssertions;
    using TestStack.BDDfy;
    using Xunit;

    public class StoryAcceptanceTests
    {
        private IManagedMediator _mediator;
        private ContextCollection _collection;
        private NewStory _newStoryCommand;
        private IResponse<Guid> _result;

        public StoryAcceptanceTests()
        {
            var container = Bootstrapper.Bootstrap();
            _mediator = container.Resolve<IManagedMediator>();
        }

        [Fact]
        public void CreateAStory()
        {
            this.Given(t => t.AContext().Wait())
                .And(t => t.AStory())
                .When(t => t.TheStoryIsSaved().Wait())
                .Then(t => t.AValidLocationIsRecieved())
                .And(t => t.TheCollectionCanBeRetrieved().Wait())
                .BDDfy();
        }
        
        private async Task AContext()
        {
            var response = await _mediator.Send(new NewContextCollection
            {
                Name = new Name("My Contexts"), Contexts = new List<Context>
                {
                    new Context(Guid.NewGuid(), new Name("Steve Jackson Books"))
                }
            });

            var collectionResponse = await _mediator.Send(new GetContextCollection {Id = response.Result});
            collectionResponse.Should().NotBeNull();
            _collection = collectionResponse.Result;
        }

        private void AStory()
        {
            var contextId = _collection.Contexts.First().Id;
            _newStoryCommand = new NewStory{Name = new Name("The Warlock Of Firetop Mountain"), ContextId = contextId };
        }

        private async Task TheStoryIsSaved()
        {
            _result = await _mediator.Send(_newStoryCommand);
        }

        private void AValidLocationIsRecieved()
        {
            _result.Should().NotBeNull();
            _result.Result.Should().NotBeEmpty();
        }

        private async Task TheCollectionCanBeRetrieved()
        {
            var query = new GetStory {Id = _result.Result};
            var story = await _mediator.Send(query);
            story.Should().NotBeNull();
            story.Result.Should().NotBeNull();
            story.Result.Id.Should().Be(query.Id);
        }
    }
}