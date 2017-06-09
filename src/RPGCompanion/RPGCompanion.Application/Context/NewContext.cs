namespace RPGCompanion.Application.Context
{
    using System;
    using Domain;
    using RPGCompanion.Domain.Model.Context;
    using RPGCompanion.Domain.Model.Values;

    public class CreateContext: DomainCommand<Guid>
    {
        public Name Name { get; set; }
        public Description Description { get; set; }
    }
}