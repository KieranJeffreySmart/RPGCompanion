namespace RPGCompanion.Application.Context
{
    using System;
    using RPGCompanion.Domain.Model.Values;

    public class AddUnitType: NamedCommand
    {
        public Name Name { get; set; }
        public Guid ContextId { get; set; }
    }
}