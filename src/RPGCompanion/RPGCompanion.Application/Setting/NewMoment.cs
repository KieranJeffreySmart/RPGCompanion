namespace RPGCompanion.Application.Setting
{
    using System;
    using Domain;
    using RPGCompanion.Domain.Model.Values;

    public class NewMoment : DomainCommand<Guid>
    {
        public Name Name { get; set; }
        public Guid EnvironmentId { get; set; }
    }
}