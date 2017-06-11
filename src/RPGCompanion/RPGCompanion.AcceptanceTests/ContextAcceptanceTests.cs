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
    using RPGCompanion.AcceptanceTests.Data;

    public class ContextAcceptanceTests
    {
        private CreateContext _contextCommand;

        private readonly IManagedMediator _mediator;
        private Guid _contextId;
        private Context _context;
        private List<AddCharacterType> _characterTypes;
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
            _characterTypes = FightingFantasyContext.FightingFantasyCharacterTypeCommands;
        }

        public void ASetOfItemTypes()
        {
            _itemTypes = FightingFantasyContext.FightingFantasyItemTypeCommands;
        }

        private async Task CreatingAContext()
        {
            _contextCommand = FightingFantasyContext.FightingFantasyContextCommand;

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
                FightingFantasyContext.ScoreUnitType,
                FightingFantasyContext.DoseUnitType,
                FightingFantasyContext.MetersUnitType,
                FightingFantasyContext.RationUnitType
            };

            _context.Should().NotBeNull();
            _context?.UnitTypes.Select(ut => ut.Name).ShouldAllBeEquivalentTo(unitTypes.Select(ut => ut.Name));
        }
    }
}
