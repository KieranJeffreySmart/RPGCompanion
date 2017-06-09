namespace RPGCompanion.Domain.Model.Character
{
    using Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Values;

    public class Character: NamedAggregate
    {
        public Character(Guid id, Name name, Description description, IEnumerable<TraitGroup> traits) : base(id, name, description)
        {
            Traits = traits.ToList();
        }

        public ICollection<TraitGroup> Traits { get; }
    }
}
