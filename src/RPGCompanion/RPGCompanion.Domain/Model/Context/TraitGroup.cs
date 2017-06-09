namespace RPGCompanion.Domain.Model.Context
{
    using System.Collections.Generic;
    using Domain;
    using Values;

    public class TraitGroup: DomainValueType
    {
        private readonly List<Trait> _traits = new List<Trait>();

        public IReadOnlyList<Trait> Traits => _traits;

        public TraitGroup(Name name, IEnumerable<Trait> traits)
        {
            _traits.AddRange(traits);
            Name = name;
        }

        public Name Name { get; }
    }
}