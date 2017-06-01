namespace RPGCompanion.Application.Context
{
    using System;
    using Domain;

    public class QuickContext: DomainCommand<Guid>
    {
        public CreateContext Context { get; set; }
    }
}