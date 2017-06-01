namespace RPGCompanion.Application.Character
{
    using System;
    using System.Collections.Generic;
    using RPGCompanion.Domain.Model.Character;

    public class CreateCharacter : NamedCommand<Guid>
    {
        public List<Guid> Items { get; set; }
        public List<TraitGroup> Traits { get; set; }
    }
}