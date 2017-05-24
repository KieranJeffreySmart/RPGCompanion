namespace RPGCompanion.Application.Commands
{
    using System;
    using Domain.Model.Values;
    using Mediator;
    public class NewStory: DomainCommand<Guid>
    {
        public Name Name { get; set; }

        public Guid ContextId { get; set; }
    }
}