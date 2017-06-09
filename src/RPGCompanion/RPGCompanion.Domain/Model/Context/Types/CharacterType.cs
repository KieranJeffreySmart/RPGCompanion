namespace RPGCompanion.Domain.Model.Context.Types
{
    using System.Collections.Generic;
    using Domain;
    using Values;

    public class CharacterType: DomainValueType
    {
        private readonly List<TraitGroup> _traitGroups = new List<TraitGroup>();

        public CharacterType(Name name, IEnumerable<TraitGroup> traits)
        {
            Name = name;
            _traitGroups.AddRange(traits);
        }

        public IReadOnlyList<TraitGroup> TraitGroups => _traitGroups;

        public Name Name { get; }
    }
}