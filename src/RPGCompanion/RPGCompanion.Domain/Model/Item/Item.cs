namespace RPGCompanion.Domain.Model.Item
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Character;
    using Values;

    public class Item : NamedEntity<Guid>
    {
        public Item(Guid id, Name name, Description description, IEnumerable<TraitGroup> traits) : base(id, name, description)
        {
            Traits = traits.ToList();
        }

        public ICollection<TraitGroup> Traits { get; }
    }
}
