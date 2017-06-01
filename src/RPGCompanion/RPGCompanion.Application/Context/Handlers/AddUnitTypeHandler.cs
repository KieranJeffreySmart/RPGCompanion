namespace RPGCompanion.Application.Context.Handlers
{
    using System.Threading.Tasks;
    using Domain.Mediator;
    using RPGCompanion.Domain.Model.Context.Types;
    using RPGCompanion.Domain.Repository;

    public class AddUnitTypeHandler : IPrivateMessageHandler<AddUnitType>
    {
        private readonly IContextRepository _repo;

        public AddUnitTypeHandler(IContextRepository repo)
        {
            _repo = repo;
        }

        public async Task Handle(AddUnitType command)
        {
            var context = await _repo.Get(command.ContextId);
            context.AddUnitType(command.Name, command.Description);
        }
    }
}