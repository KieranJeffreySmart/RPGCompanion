namespace RPGCompanion.Application.Context.Handlers
{
    using System.Threading.Tasks;
    using Domain.Mediator;
    using RPGCompanion.Domain.Repository;

    public class AddItemTypeHandler : IPrivateMessageHandler<AddItemType>
    {
        private readonly IContextRepository _repo;

        public AddItemTypeHandler(IContextRepository repo)
        {
            _repo = repo;
        }

        public async Task Handle(AddItemType command)
        {
            var context = await _repo.Get(command.ContextId);
            context.AddItemType(command.Name, command.Traits);
        }
    }
}