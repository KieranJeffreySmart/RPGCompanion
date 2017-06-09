namespace RPGCompanion.Application.Context.Handlers
{
    using System;
    using System.Threading.Tasks;
    using Domain.Mediator;

    public class QuickContextHandler : IPrivateMessageHandler<QuickContext, Guid>
    {
        private readonly IManagedMediator _mediator;

        public QuickContextHandler(IManagedMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Guid> Handle(QuickContext command)
        {
            var contextResponse = await _mediator.Send(command.Context);

            foreach (var commandItemType in command.ItemTypes)
            {
                commandItemType.ContextId = contextResponse.Result;
                await _mediator.Send(commandItemType);
            }

            foreach (var commandCharacterType in command.CharacterTypes)
            {
                commandCharacterType.ContextId = contextResponse.Result;
                await _mediator.Send(commandCharacterType);
            }

            return contextResponse.Result;
        }
    }
}