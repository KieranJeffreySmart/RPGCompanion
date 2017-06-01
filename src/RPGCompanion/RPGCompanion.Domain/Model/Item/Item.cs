namespace RPGCompanion.Domain.Model.Item
{
    using System;
    using System.Collections.Generic;
    using Character;
    using Values;

    public class Item : CharacterEntity
    {
        public Item(Guid id, Name name, Description description, ICollection<Trait> traits, Unit quantity) : base(id, name, description, traits)
        {
            Quantity = quantity;
        }

        public Unit Quantity { get; }
    }
}
