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
    using Application.Item;
    using Application.Narrative;
    using Application.Setting;
    using Domain.Model.Context;
    using Domain.Model.Narrative;
    using Domain.Model.Narrative.Plot;
    using Domain.Model.Values;
    using FluentAssertions;
    using TestStack.BDDfy;
    using Xunit;
    using Story = Domain.Model.Narrative.Story;

    public class StoryAcceptanceTests
    {
        private readonly IManagedMediator _mediator;
        private NewStory _story;
        private Guid _storyId;
        private List<Story> _stories;

        public StoryAcceptanceTests()
        {
            var container = Bootstrapper.Bootstrap();
            _mediator = container.Resolve<IManagedMediator>();
        }

        [Fact]
        public void StartAStory()
        {
            this.Given(t => t.AStory())
                .When(t => t.TheStoryIsCreated().Wait())
                .And(t => t.ViewingAllStories().Wait())
                .Then(t => t.TheNewStoryExists())
                .BDDfy();
        }

        private void AStory()
        {
            _story = new NewStory
            {
                Name = new Name("Warlock of Firetop Mountain"),
                Description = new Description("Our first S.J. and I.L. book")
            };
        }

        private async Task TheStoryIsCreated()
        {
            var response = await _mediator.Send(_story);
            response.Should().NotBeNull();

            _storyId = response.Result;
        }

        private async Task ViewingAllStories()
        {
            var response = await _mediator.Send(new ViewStories());
            response.Should().NotBeNull();

            _stories = response.Result.ToList();
        }

        private void TheNewStoryExists()
        {
            _stories.Should().NotBeNull();
            _stories.Select(i => i.Id).Single().Should().Be(_storyId);
            _stories.Select(i => i.Name).Single().Should().Be(_story.Name);
        }
    }
}