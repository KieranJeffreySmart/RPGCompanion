namespace RPGCompanion.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using Domain;
    using Values;

    public class NamedAggregate : NamedEntity<Guid>, IDomainEventProvider
    {
        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();

        public NamedAggregate(Guid id, Name name, Description description) : base(id, name, description)
        {
        }

        public IEnumerable<IDomainEvent> GetUncomittedDomainEvents()
        {
            return _events;
        }

        public void Commit()
        {
            _events.Clear();
        }

        protected void RaiseEvent(IDomainEvent domainEvent)
        {
            _events.Add(domainEvent);
        }
    }
}