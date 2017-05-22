using System;
using System.Collections.Generic;

namespace RPGCompanion.Domain.Abstract
{
    public class Character
    {
        public Character(List<Trait> traits)
        {
            Id = Guid.NewGuid();
            Traits = traits;
        }

        public Guid Id { get; }

        public Guid ContextId { get; }

        public List<Trait> Traits { get; }
        
        internal Character Clone()
        {
            return new Character(Traits);
        }
    }
}
