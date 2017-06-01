namespace RPGCompanion.AcceptanceTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Api.IoC;
    using Application.Character;
    using Application.Context;
    using Application.Domain.Mediator;
    using Application.Narrative;
    using Application.Setting;
    using Domain.Model.Context;
    using Domain.Model.Narrative;
    using Domain.Model.Narrative.Plot;
    using Domain.Model.Values;
    using FluentAssertions;
    using TestStack.BDDfy;
    using Xunit;

    public class StoryAcceptanceTests
    {
        private readonly IManagedMediator _mediator;
        private IResponse<Guid> _response;
        private Scene _scene;
        private NewMoment _openingMoment;
        private NewGlobalEnvironment _openingEnvironment;
        private CreateContext _contextCommand;
        private Context _context;
        private List<Guid> _storyLines;
        private NewLocation _location;
        private CreateCharacter _newCharacter;
        private List<AddUnitType> _unitTypes;
        private List<NewItem> _actorProps;
        private NewStory _newStoryCommand;
        private NewLocalEnvironment _localEnvironment;
        private StoryLine _storySoFar;

        public StoryAcceptanceTests()
        {
            var container = Bootstrapper.Bootstrap();
            _mediator = container.Resolve<IManagedMediator>();
        }

        [Fact]
        public void StartAStory()
        {
        }
    }
}