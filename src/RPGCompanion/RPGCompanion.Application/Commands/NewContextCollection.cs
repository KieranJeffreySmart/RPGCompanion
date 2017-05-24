namespace RPGCompanion.Application.Commands
{
    using System;
    using System.Collections.Generic;
    using Domain.Model.Context;
    using Domain.Model.Values;

    public class NewContextCollection: DomainCommand<Guid>
    {
        public Name Name { get; set; }
        public List<Context> Contexts { get; set; }
    }
}