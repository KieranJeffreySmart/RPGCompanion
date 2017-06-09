namespace RPGCompanion.Application.Domain
{
    using System.Threading.Tasks;
    using Mediator;
    using RPGCompanion.Domain.Domain;

    public class DomainEventPublisher
    {
        private readonly IManagedMediator _mediator;

        public DomainEventPublisher(IManagedMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IResponse> Publish<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent
        {
            return await _mediator.Publish(new DomainEventMessage<TEvent> {Event = domainEvent});
        }
    }
}