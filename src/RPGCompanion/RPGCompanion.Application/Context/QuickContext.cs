namespace RPGCompanion.Application.Context
{
    using System;
    using System.Collections.Generic;
    using Domain;

    public class QuickContext: DomainCommand<Guid>
    {
        public CreateContext Context { get; set; }
        public IEnumerable<AddCharacterType> CharacterTypes { get; set; }
        public IEnumerable<AddItemType> ItemTypes { get; set; }
    }
}