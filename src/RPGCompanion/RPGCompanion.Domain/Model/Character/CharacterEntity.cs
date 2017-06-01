namespace RPGCompanion.Domain.Model.Character
{
    using System;
    using System.Collections.Generic;
    using Values;

    public class CharacterEntity: NamedEntity<Guid>
    {
        public ICollection<Trait> Traits { get; }

        public CharacterEntity(Guid id, Name name, Description description, ICollection<Trait> traits): base(id, name, description)
        {
            Traits = traits;
        }
    }
}
