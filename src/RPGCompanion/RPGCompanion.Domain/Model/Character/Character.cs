namespace RPGCompanion.Domain.Model.Character
{
    using System;
    using System.Collections.Generic;
    using Item;
    using Values;

    public class Character: CharacterEntity
    {
        public Character(Guid id, Name name, Description description, ICollection<Trait> traits) : base(id, name, description, traits)
        {
            
        }

        public ICollection<Item> Items { get; } = new List<Item>();
    }
}
