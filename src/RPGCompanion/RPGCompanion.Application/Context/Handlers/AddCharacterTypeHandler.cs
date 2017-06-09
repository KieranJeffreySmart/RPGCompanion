namespace RPGCompanion.Application.Context.Handlers
{
    using System.Threading.Tasks;
    using Domain.Mediator;
    using RPGCompanion.Domain.Repository;

    public class AddCharacterTypeHandler : IPrivateMessageHandler<AddCharacterType>
    {
        private readonly IContextRepository _repo;

        public AddCharacterTypeHandler(IContextRepository repo)
        {
            _repo = repo;
        }

        public async Task Handle(AddCharacterType command)
        {
            var context = await _repo.Get(command.ContextId);
            context.AddCharacterType(command.Name, command.Traits);
        }
    }
}