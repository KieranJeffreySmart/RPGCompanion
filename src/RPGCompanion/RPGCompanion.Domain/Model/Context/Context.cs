namespace RPGCompanion.Domain.Model.Context
{
    using System;
    using System.Collections.Generic;
    using Character;
    using DomainCore;
    using GameEntities;
    using Location;
    using Timeline;
    using Types;
    using Values;
    using Action = Timeline.Action;

    public class Context: DomainEntity<Guid>
    {
        public Name Name { get; }
        public Description Description { get; }
        public List<Character> Characters { get; }
        public List<UnitType> UnitTypes { get; }
        public List<ItemType> ItemTypes { get; }
        public List<Item> Items { get; }
        public List<Thing> Things { get; }
        public List<Action> Actions { get; }
        public List<Event> Events { get; }
        public List<Creature> Creatures { get; }
        public List<LocalEnvironment> LocalEnvironments { get; }
        public List<GlobalEnvironment> GlobalEnvironments { get; }
        public List<Location> Locations { get; }

        public Context(Guid id, Name name) : base(id)
        {
            Name = name;
        }
    }
}
