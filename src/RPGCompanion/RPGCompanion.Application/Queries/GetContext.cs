namespace RPGCompanion.Application.Queries
{
    using System;
    using Domain.Model.Context;

    public class GetContext: DomainQuery<Context>
    {
        public Guid CollectionId { get; set; }
        public Guid ContextId { get; set; }
    }
}