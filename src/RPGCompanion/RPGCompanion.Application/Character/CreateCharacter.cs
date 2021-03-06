﻿namespace RPGCompanion.Application.Character
{
    using System;
    using System.Collections.Generic;
    using RPGCompanion.Domain.Model.Character;

    public class CreateCharacter : NamedCommand<Guid>
    {
        public IEnumerable<TraitGroup> Traits { get; set; }
    }
}