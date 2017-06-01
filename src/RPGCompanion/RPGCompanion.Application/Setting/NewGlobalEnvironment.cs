namespace RPGCompanion.Application.Setting
{
    using System;
    using Domain;
    using RPGCompanion.Domain.Model.Values;

    public class NewGlobalEnvironment : DomainCommand<Guid>
    {
        public Name Name { get; set; }
        public Guid ContextId { get; set; }
    }
}