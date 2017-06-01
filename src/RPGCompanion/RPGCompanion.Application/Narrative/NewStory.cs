namespace RPGCompanion.Application.Narrative
{
    using System;
    using Domain;
    using RPGCompanion.Domain.Model.Values;

    public class NewStory: DomainCommand<Guid>
    {
        public Name Name { get; set; }

        public Guid ContextId { get; set; }
        public Description Description { get; set; }
    }
}