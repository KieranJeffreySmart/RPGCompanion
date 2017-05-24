namespace RPGCompanion.Domain.Model.Character
{
    using System;
    using System.Collections.Generic;

    public class Character
    {
        public Character(List<Trait> traits)
        {
            Id = Guid.NewGuid();
            Traits = traits;
        }

        public Guid Id { get; }

        public List<Trait> Traits { get; }
        
        internal Character Clone()
        {
            return new Character(Traits);
        }
    }
}
