namespace RPGCompanion.Application.Context
{
    using System;
    using System.Collections.Generic;
    using Domain;
    using RPGCompanion.Domain.Model.Context;
    using RPGCompanion.Domain.Model.Values;

    public class AddCharacterType : DomainCommand
    {
        public Name Name { get; set; }
        public IEnumerable<TraitGroup> Traits { get; set; }
        public Guid ContextId { get; set; }
    }
}