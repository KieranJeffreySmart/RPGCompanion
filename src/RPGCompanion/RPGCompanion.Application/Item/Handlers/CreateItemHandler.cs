namespace RPGCompanion.Application.Item.Handlers
{
    using System;
    using System.Threading.Tasks;
    using Domain.Mediator;
    using RPGCompanion.Domain.Model.Item;
    using RPGCompanion.Domain.Repository;

    public class CreateItemHandler : IPrivateMessageHandler<CreateItem, Guid>
    {
        private readonly IItemRepository _repo;

        public CreateItemHandler(IItemRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(CreateItem command)
        {
            var id = Guid.NewGuid();
            await _repo.Add(new Item(id, command.Name, command.Description, command.Traits));
            return id;
        }
    }
}