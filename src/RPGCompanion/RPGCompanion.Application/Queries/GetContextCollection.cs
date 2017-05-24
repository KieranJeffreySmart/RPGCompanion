namespace RPGCompanion.Application.Queries
{
    using System;
    using Domain.Model.Context;

    public class GetContextCollection : DomainQuery<ContextCollection>
    {
        public Guid Id { get; set; }
    }
}