namespace RPGCompanion.Domain.Model.GameEntities
{
    using System;
    using System.Collections.Generic;
    using Character;
    using Timeline;
    using Values;

    public class Creature : GameEntity
    {
        public Creature(Guid id, Timeline timeline, Character character, Name name, List<Item> items) : base(id, timeline, character, name)
        {
            Items = items;
        }

        List<Item> Items { get; }

        internal Creature Clone()
        {
            throw new NotImplementedException();
        }
    }
}
