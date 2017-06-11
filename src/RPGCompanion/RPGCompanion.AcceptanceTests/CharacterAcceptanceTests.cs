namespace RPGCompanion.AcceptanceTests
{
    using System;
    using System.Threading.Tasks;
    using Application.Character;
    using TestStack.BDDfy;
    using Xunit;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Domain.Model.Character;
    using Api.IoC;
    using Application.Domain.Mediator;
    using RPGCompanion.AcceptanceTests.Data;

    public class CharacterAcceptanceTests
    {
        private CreateCharacter _characterCommand;
        private List<TraitGroup> _traits;
        private readonly IManagedMediator _mediator;
        private Guid _characterId;
        private List<Character> _characters;

        public CharacterAcceptanceTests()
        {
            var container = Bootstrapper.Bootstrap();
            _mediator = container.Resolve<IManagedMediator>();
        }

        [Fact]
        public void Character_Create()
        {
            this.Given(t => t.ACharacter())
                .And(t => t.TheCharacterHasTraits())
                .When(t => t.TheCharacterIsCreated().Wait())
                .And(t => t.ViewingAllCharacters().Wait())
                .Then(t=> t.TheNewCharacterExists())
                .BDDfy();
        }

        private void ACharacter()
        {
            _characterCommand = SampleCharacters.CreateOpheliaLapwigCommand;
        }

        private void TheCharacterHasTraits()
        {
            _traits = SampleCharacters.ConansTraits;
        }
        
        private async Task TheCharacterIsCreated()
        {
            _characterCommand.Traits = _traits;
            var response = await _mediator.Send(_characterCommand);

            response.Should().NotBeNull();
            _characterId = response.Result;
        }

        private async Task ViewingAllCharacters()
        {
            var response = await _mediator.Send(new ViewCharacters());

            response.Should().NotBeNull();
            _characters = response.Result.ToList();
        }

        private void TheNewCharacterExists()
        {
            _characters.Should().NotBeNull();
            _characters.Select(i => i.Id).Single().Should().Be(_characterId);
            _characters.Select(i => i.Name).Single().Should().Be(_characterCommand.Name);
            _characters.SelectMany(i => i.Traits.Select(t => t.Name)).ShouldBeEquivalentTo(_characterCommand.Traits.Select(t => t.Name));
        }
    }
}