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
        private readonly Name _contextName = new Name("Fighting Fantasy Books");
        private readonly Description _contextDescription = new Description("Role Play Books by Steve Jackson and Ian Livingstone");
        private Guid _contextId;
        private Context _context;
        private List<AddCharacterType> _characterTypes;
        private readonly UnitType _scoreUnitType = new UnitType(new Name("Score"), new Description("Character Attribute Scores"));
        private readonly UnitType _doseUnitType = new UnitType(new Name("Dose"), new Description("A Dose of Potion"));
        private readonly UnitType _rationUnitType = new UnitType(new Name("Ration"), new Description("A Dose of Potion"));
        private readonly UnitType _metersUnitType = new UnitType(new Name("Meters"), new Description("Metric Measurement"));
        private List<AddItemType> _itemTypes;
        private IEnumerable<Context> _contexts;

        public ContextAcceptanceTests()
        {
            var container = Bootstrapper.Bootstrap();
            _mediator = container.Resolve<IManagedMediator>();
        }

        [Fact]
        public void CreateAContext()
        {
            this.Given(t => t.ASetOfCharacterTypes())
                .And(t => t.ASetOfItemTypes())
                .When(t => t.CreatingAContext().Wait())
                .And(t => t.ViewingAllContexts().Wait())
                .Then(t => t.TheNewContextExists())
                .And(t => t.TheContextHasNewUnitTypes())
                .BDDfy();
        }

        public void ASetOfCharacterTypes()
        {
            _characterTypes = new List<AddCharacterType>
            {
                new AddCharacterType{ Name = new Name("Player Character"), Traits = PlayerTraits() }
            };
        }

        public void ASetOfItemTypes()
        {
            _itemTypes = new List<AddItemType>
            {
                new AddItemType{ Name = new Name("Standard Lantern"), Traits = StandardLanternTraits() },
                new AddItemType{ Name = new Name("Standard Sword"), Traits = StandardSwordTraits() },
                new AddItemType{ Name = new Name("Standard Rations"), Traits = StandardRationsTraits() },
                new AddItemType{ Name = new Name("Skill Potion"), Traits = StandardPotionTraits() }
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

        private async Task CreatingAContext()
        {
            _contextCommand = new CreateContext
            {
                Name = _contextName,
                Description = _contextDescription
            };

            var quickContextCommand = new QuickContext
            {
                Context = _contextCommand,
                CharacterTypes = _characterTypes,
                ItemTypes = _itemTypes
            };

            var response = await _mediator.Send(quickContextCommand);
            response.Should().NotBeNull();
            response.Result.Should().NotBeEmpty();
            _contextId = response.Result;
        }

        private async Task ViewingAllContexts()
        {
            var contextQuery = new ViewContexts();
            var response = await _mediator.Send(contextQuery);
            response.Should().NotBeNull();
            _contexts = response.Result;
            _context = _contexts.SingleOrDefault(c => c.Id == _contextId);
        }

        private void TheNewContextExists()
        {
            _context.Should().NotBeNull();
            _context?.Id.Should().Be(_contextId);
            _context?.CharacterTypes.Select(ct => ct.Name).ShouldBeEquivalentTo(_characterTypes.Select(ct => ct.Name));
            _context?.ItemTypes.Select(ct => ct.Name).ShouldBeEquivalentTo(_itemTypes.Select(ct => ct.Name));
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

            _context.Should().NotBeNull();
            _context?.UnitTypes.Select(ut => ut.Name).ShouldAllBeEquivalentTo(unitTypes.Select(ut => ut.Name));
        }
    }
}
