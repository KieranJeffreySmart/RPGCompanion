namespace RPGCompanion.Application.Context
{
    using System;
    using Domain;
    using RPGCompanion.Domain.Model.Context;

    public class ReadContext: DomainQuery<Context>
    {
        public Guid ContextId { get; set; }
    }
}