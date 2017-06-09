namespace RPGCompanion.Application.Item
{
    using System;
    using System.Collections.Generic;
    using RPGCompanion.Domain.Model.Character;

    public class CreateItem : NamedCommand<Guid>
    {
        public IEnumerable<TraitGroup> Traits { get; set; }
    }
}