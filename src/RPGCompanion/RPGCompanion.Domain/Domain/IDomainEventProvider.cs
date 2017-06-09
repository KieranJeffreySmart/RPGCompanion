namespace RPGCompanion.Domain.Domain
{
    using System.Collections.Generic;

    public interface IDomainEventProvider
    {
        IEnumerable<IDomainEvent> GetUncomittedDomainEvents();
        void Commit();
    }
}