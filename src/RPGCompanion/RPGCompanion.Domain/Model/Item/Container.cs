namespace RPGCompanion.Domain.Model.Item
{
    using System;
    using System.Collections.Generic;
    using Character;
    using Values;

    public class Container: Item
    {
        public Container(Guid id, Name name, Description description, ICollection<Trait> traits, Unit quantity, Unit contentCapacity) : base(id, name, description, traits, quantity)
        {
            ContentCapacity = contentCapacity;
        }

        public Unit ContentCapacity { get; }

        public ICollection<Item> Content { get; } = new List<Item>();
    }
}
