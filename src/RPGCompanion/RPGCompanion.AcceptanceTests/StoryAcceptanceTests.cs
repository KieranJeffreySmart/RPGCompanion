namespace RPGCompanion.AcceptanceTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Api.IoC;
    using Application.Domain.Mediator;
    using Application.Narrative;
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
        public void CreateAStory()
        {
            this.Given(t => t.AStory())
                .And(t => t.AContext())
                .And(t => t.ASetting())
                .When(t => t.TheStoryIsCreated().Wait())
                .And(t => t.ViewingAllStories().Wait())
                .Then(t => t.TheNewStoryExists())
                .BDDfy();
        }

        [Fact]
        public void StartAStory()
        {
            this.Given(t => t.AStoryIsOpen())
                .When(t => t.StartingTheStory())
                .Then(t => t.ICanReadADescriptinoOfTheStory())
                .And(t => t.ICanReadADescriptionOfTheSetting())
                .And(t => t.IAmAbleToCreateTheOpeningScene())
                .BDDfy();
        }
        
        [Fact]
        public void Character_AddedToStory()
        {
            this.Given(t => t.AStoryIsOpen())
                .And(t => t.ACharacterExists())
                .When(t => t.TheCharacterIsAddedToTheStory())
                .And(t => t.ACharacterTypeIsSelected())
                .Then(t => t.NewTraitsBecomeVisible())
                .BDDfy();
        }

        private void ACharacterExists()
        {
            throw new NotImplementedException();
        }

        private void TheCharacterIsAddedToTheStory()
        {
            throw new NotImplementedException();
        }

        private void ACharacterTypeIsSelected()
        {
            throw new NotImplementedException();
        }

        private void NewTraitsBecomeVisible()
        {
            throw new NotImplementedException();
        }

        private void AStory()
        {
            _story = new NewStory
            {
                Name = new Name("Warlock of Firetop Mountain"),
                Description = new Description("Our first S.J. and I.L. book")
            };
        }

        private void AContext()
        {
            throw new NotImplementedException();
        }

        private void ASetting()
        {
            throw new NotImplementedException();
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

        private void AStoryIsOpen()
        {
            throw new NotImplementedException();
        }

        private void StartingTheStory()
        {
            throw new NotImplementedException();
        }

        private void ICanReadADescriptinoOfTheStory()
        {
            throw new NotImplementedException();
        }

        private void ICanReadADescriptionOfTheSetting()
        {
            throw new NotImplementedException();
        }

        private void IAmAbleToCreateTheOpeningScene()
        {
            throw new NotImplementedException();
        }
    }
}