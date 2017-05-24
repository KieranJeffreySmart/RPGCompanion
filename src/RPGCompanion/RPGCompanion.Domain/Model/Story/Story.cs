namespace RPGCompanion.Domain.Model.Story
{
    using System;
    using DomainCore;
    using Values;

    public class Story: DomainEntity<Guid>
    {
        public Story(Guid id, Name name) : base(id)
        {
            Name = name;
        }

        public Name Name { get; }
    }
}