namespace RPGCompanion.Application.Commands
{
    using System;
    using Domain.Model.Values;

    public class NewContext: DomainCommand<Guid>
    {
        public Guid CollectionId { get; set; }
        public Name Name { get; set; }
    }
}