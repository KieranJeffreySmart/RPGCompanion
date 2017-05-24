namespace RPGCompanion.AcceptanceTests
{
    using System;
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

    public class ContextAcceptanceTests
    {
        private NewContext _contextCommand;
        private NewContextCollection _collectionCommand;
        private readonly Name _collectionName = new Name("NewCollection");
        private readonly Name _contextName = new Name("Steve Jackson");

        private readonly IManagedMediator _mediator;
        private IResponse<Guid> _result;
        private IResponse<ContextCollection> _collectionResult;
        private IResponse<Context> _contextResult;

        public ContextAcceptanceTests()
        {
            var container = Bootstrapper.Bootstrap();
            _mediator = container.Resolve<IManagedMediator>();
        }

        [Fact]
        void CreateCollection()
        {
            this.Given(t => t.ACollection())
                .When(t => t.TheCollectionIsSaved().Wait())
                .Then(t => t.AValidLocationIsRecieved())
                .And(t => t.TheCollectionCanBeRetrieved().Wait())
                .BDDfy();
        }

        [Fact]
        public void CreateContext()
        {
            this.Given(t => t.ACollection())
                .And(t => t.TheCollectionIsSaved().Wait())
                .And(t => t.TheCollectionIsRetrieved())
                .And(t => t.AContext())
                .And(t => t.SaveAContext().Wait())
                .Then(t => t.AValidLocationIsRecieved())
                .And(t => t.TheContextCanBeRetrieved())
                .BDDfy();
        }

        private void ACollection()
        {
            _collectionCommand = new NewContextCollection { Name = _collectionName };
        }

        private async Task TheCollectionIsSaved()
        {
            _result = await _mediator.Send(_collectionCommand);
        }

        private void AValidLocationIsRecieved()
        {
            _result.Should().NotBeNull();
            _result.Result.Should().NotBeEmpty();
        }

        private async Task TheCollectionIsRetrieved()
        {
            GetContextCollection getCollectionQuery = new GetContextCollection { Id = _result.Result };
            _collectionResult = await _mediator.Send(getCollectionQuery);
        }

        private async Task TheCollectionCanBeRetrieved()
        {
            GetContextCollection getCollectionQuery = new GetContextCollection { Id = _result.Result };
            _collectionResult = await _mediator.Send(getCollectionQuery);
            _collectionResult.Should().NotBeNull();
            _collectionResult.Result.Should().NotBeNull();
            _collectionResult.Result.Id.Should().Be(getCollectionQuery.Id);
        }

        private void AContext()
        {
            _contextCommand = new NewContext { CollectionId = _result.Result, Name = _contextName };
        }

        private async Task SaveAContext()
        {
            _result = await _mediator.Send(_contextCommand);
        }

        private async Task TheContextCanBeRetrieved()
        {
            var getContextQuery = new GetContext { CollectionId = _collectionResult.Result.Id, ContextId = _result.Result };
            _contextResult = await _mediator.Send(getContextQuery);
            _contextResult.Should().NotBeNull();
            _contextResult.Result.Should().NotBeNull();
            _contextResult.Result.Id.Should().Be(getContextQuery.ContextId);
        }
    }
}
