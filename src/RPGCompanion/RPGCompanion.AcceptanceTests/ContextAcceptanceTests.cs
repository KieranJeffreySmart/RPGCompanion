namespace RPGCompanion.AcceptanceTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Api.IoC;
    using Application.Context;
    using Application.Domain.Mediator;
    using Domain.Model.Context;
    using Domain.Model.Context.Types;
    using Domain.Model.Values;
    using FluentAssertions;
    using TestStack.BDDfy;
    using Xunit;

    public class ContextAcceptanceTests
    {
        private CreateContext _contextCommand;

        private readonly IManagedMediator _mediator;
        private Creator _gamesMaster;
        private readonly Name _contextName = new Name("Fighting Fantasy Books");
        private readonly Description _contextDescription = new Description("Role Play Books by Steve Jackson and Ian Livingstone");
        private Guid _contextId;
        private Context _context;
        private List<CharacterTraitSet> _traits;
        private readonly UnitType _scoreUnitType = new UnitType(new Name("Score"), new Description("Character Attribute Scores"));
        private readonly UnitType _doseUnitType = new UnitType(new Name("Dose"), new Description("A Dose of Potion"));
        private readonly UnitType _rationUnitType = new UnitType(new Name("Ration"), new Description("A Dose of Potion"));
        private readonly UnitType _metersUnitType = new UnitType(new Name("Meters"), new Description("Metric Measurement"));

        public ContextAcceptanceTests()
        {
            var container = Bootstrapper.Bootstrap();
            _mediator = container.Resolve<IManagedMediator>();
        }

        [Fact]
        public void CreateAQuickContext()
        {
            this.Given(t => t.AGamesMaster())
                .And(t => t.ASetOfCharacterTraits())
                .And(t => t.ASetOfItemTraits())
                .When(t => t.CreateAContext().Wait())
                .Then(t => t.TheNewContextCanBeRead())
                // .And(t => t.TheContextHasNewUnitTypes())
                .BDDfy();
        }

        public void ASetOfCharacterTraits()
        {
            _traits = new List<CharacterTraitSet>
            {
                new CharacterTraitSet(new Name("Player Character"), PlayerTraits())
            };
        }

        public void ASetOfItemTraits()
        {
            _traits = new List<CharacterTraitSet>
            {
                new CharacterTraitSet(new Name("Standard Lantern"), StandardLanternTraits()),
                new CharacterTraitSet(new Name("Standard Sword"), StandardSwordTraits()),
                new CharacterTraitSet(new Name("Standard Rations"), StandardRationsTraits()),
                new CharacterTraitSet(new Name("Skill Potion"), StandardPotionTraits())
            };
        }

        private List<TraitGroup> PlayerTraits()
        {
            return new List<TraitGroup>
            {
                new TraitGroup(new Name("Scores"), new List<Trait>
                    {
                        new Trait(new Name("Skill"), new Unit(_scoreUnitType, 11)),
                        new Trait(new Name("Stamina"), new Unit(_scoreUnitType, 11)),
                        new Trait(new Name("Luck"), new Unit(_scoreUnitType, 11))
                    })
            };
        }

        private List<TraitGroup> StandardPotionTraits()
        {
            return new List<TraitGroup>
            {
                new TraitGroup(new Name("Unit"),
                    new List<Trait>
                    {
                        new Trait(new Name("Doses"), new Unit(_doseUnitType, 1))
                    })
            };
        }

        private List<TraitGroup> StandardRationsTraits()
        {
            return new List<TraitGroup>
            {
                new TraitGroup(new Name("Scores"),
                    new List<Trait>
                    {
                        new Trait(new Name("Stamina"), new Unit(_scoreUnitType, 99))
                    }),
                new TraitGroup(new Name("Unit"),
                    new List<Trait>
                    {
                        new Trait(new Name("Portions"), new Unit(_rationUnitType, 1))
                    })
            };
        }

        private List<TraitGroup> StandardLanternTraits()
        {
            return new List<TraitGroup>
            {
                new TraitGroup(new Name("Environmental"),
                    new List<Trait>
                    {
                        new Trait(new Name("Emit Light"), new Unit(_metersUnitType, 5))
                    })
            };
        }

        private List<TraitGroup> StandardSwordTraits()
        {
            return new List<TraitGroup>
            {
                new TraitGroup(new Name("Scores"),
                    new List<Trait>
                    {
                        new Trait(new Name("Stamina"), new Unit(_scoreUnitType, -2))
                    })
            };
        }

        private void AGamesMaster()
        {
            _gamesMaster = new Creator(Guid.NewGuid());
        }

        private async Task CreateAContext()
        {
            _contextCommand = new CreateContext
            {
                Creator = _gamesMaster,
                Name = _contextName,
                Description = _contextDescription
            };

            var quickContextCommand = new QuickContext
            {
                Context = _contextCommand
            };

            var response = await _mediator.Send(quickContextCommand);
            response.Should().NotBeNull();
            response.Result.Should().NotBeEmpty();
            _contextId = response.Result;
        }

        private async Task TheNewContextCanBeRead()
        {
            var contextQuery = new ReadContext { ContextId = _contextId };
            var response = await _mediator.Send(contextQuery);
            response.Should().NotBeNull();
            _context = response.Result;
            _context.Should().NotBeNull();
            _context.Id.Should().Be(contextQuery.ContextId);
        }

        private void TheContextHasNewUnitTypes()
        {
            var unitTypes = new List<UnitType>
            {
                _scoreUnitType,
                _doseUnitType,
                _metersUnitType,
                _rationUnitType
            };

            _context.UnitTypes.Select(ut => ut.Name).ShouldAllBeEquivalentTo(unitTypes.Select(ut => ut.Name));
        }
    }
}
