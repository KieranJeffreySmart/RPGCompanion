namespace RPGCompanion.AcceptanceTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Api.IoC;
    using Application.Domain.Mediator;
    using Application.Item;
    using Domain.Model.Character;
    using Domain.Model.Context.Types;
    using Domain.Model.Values;
    using FluentAssertions;
    using TestStack.BDDfy;
    using Xunit;

    public class ItemAcceptanceTests
    {
        private IManagedMediator _mediator;
        private List<CreateItem> _items;
        private List<Guid> _itemIds;

        public ItemAcceptanceTests()
        {
            var container = Bootstrapper.Bootstrap();
            _mediator = container.Resolve<IManagedMediator>();
        }

        [Fact]
        public void CreateSomeItems()
        {
            this.Given(t => t.SomeItems())
                .When(t => t.TheItemsAreCreated().Wait())
                .Then(t => t.ItemsCanBeViewed().Wait())
                .BDDfy();
        }

        private void SomeItems()
        {
            _items = new List<CreateItem>
            {
                new CreateItem
                {
                    Name = new Name("Lantern"),
                    Description = new Description(""),
                    Traits = new List<TraitGroup>
                    {
                        new TraitGroup(new Name(""), new List<Trait>())
                    }
                },
                new CreateItem
                {
                    Name = new Name("Sword"),
                    Description = new Description(""),
                    Traits = new List<TraitGroup>
                    {
                        new TraitGroup(new Name(""), new List<Trait>())
                    }
                },
                new CreateItem
                {
                    Name = new Name("Potion"),
                    Description = new Description(""),
                    Traits = new List<TraitGroup>
                    {
                        new TraitGroup(new Name(""), new List<Trait>())
                    }
                },
                new CreateItem
                {
                    Name = new Name("Rations"),
                    Description = new Description(""),
                    Traits = new List<TraitGroup>
                    {
                        new TraitGroup(new Name(""), new List<Trait>())
                    }
                },
                new CreateItem
                {
                    Name = new Name("Small Bag"),
                    Description = new Description(""),
                    Traits = new List<TraitGroup>
                    {
                        new TraitGroup(new Name("Container"), new List<Trait>
                        {
                            new Trait(new Name("Capacity"), new Unit(new UnitType(new Name("Millilitres"), new Description("Metric Measurement")), 500))
                        })
                    }
                },
                new CreateItem
                {
                    Name = new Name("Gold"),
                    Description = new Description(""),
                    Traits = new List<TraitGroup>
                    {
                        new TraitGroup(new Name(""), new List<Trait>())
                    }
                }
            };
        }

        private async Task TheItemsAreCreated()
        {
            _itemIds = new List<Guid>();
            foreach (var createItem in _items)
            {
                var response = await _mediator.Send(createItem);
                _itemIds.Add(response.Result);
            }
        }

        private async Task ItemsCanBeViewed()
        {
            var viewItemsCommand = new ViewItems();
            var response = await _mediator.Send(viewItemsCommand);
            var items = response.Result.ToList();
            items.Should().NotBeNull();
            items.Select(i => i.Id).ShouldAllBeEquivalentTo(_itemIds);
            items.Select(i => i.Name).ShouldAllBeEquivalentTo(_items.Select(i => i.Name));
            items.SelectMany(i => i.Traits.Select(t => t.Name)).ShouldBeEquivalentTo(_items.SelectMany(i => i.Traits.Select(t => t.Name)));
        }
    }
}