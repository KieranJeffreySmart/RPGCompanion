namespace RPGCompanion.Application.Domain
{
    using Mediator;
    using RPGCompanion.Domain.Domain;

    public class DomainEventMessage<TEvent> : IPublicMessage where TEvent : IDomainEvent
    {
        public TEvent Event { get; set; }
    }
}