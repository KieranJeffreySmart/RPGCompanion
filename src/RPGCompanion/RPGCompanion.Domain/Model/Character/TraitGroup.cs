namespace RPGCompanion.Domain.Model.Character
{
    using System.Collections.Generic;
    using Domain;
    using Values;

    public class TraitGroup: DomainValueType
    {
        public TraitGroup(IReadOnlyCollection<Trait> traits, Name name)
        {
            Traits = traits;
            Name = name;
        }

        public Name Name { get; }

        public IReadOnlyCollection<Trait> Traits { get; }
    }
}