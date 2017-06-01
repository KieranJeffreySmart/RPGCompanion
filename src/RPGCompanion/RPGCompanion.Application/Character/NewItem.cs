namespace RPGCompanion.Application.Character
{
    using System;
    using RPGCompanion.Domain.Model.Values;

    public class NewItem : NamedCommand<Guid>
    {
        public Unit Quantity { get; set; }
    }
}