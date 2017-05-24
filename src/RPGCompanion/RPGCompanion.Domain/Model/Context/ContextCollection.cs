namespace RPGCompanion.Domain.Model.Context
{
    using System;
    using System.Collections.Generic;
    using DomainCore;
    using Values;

    public class ContextCollection: DomainEntity<Guid>
    {
        public ContextCollection(Guid id, Name name, List<Context> contexts) : base(id)
        {
            Name = name;
            Contexts = contexts ?? new List<Context>();
        }

        public Name Name { get; }

        public List<Context> Contexts { get; }
    }
}