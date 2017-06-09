namespace RPGCompanion.Application.Item.Handlers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Mediator;
    using RPGCompanion.Domain.Model.Item;
    using RPGCompanion.Domain.Repository;

    public class ViewItemsHandler : IPrivateMessageHandler<ViewItems, IEnumerable<Item>>
    {
        private readonly IItemRepository _repo;

        public ViewItemsHandler(IItemRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Item>> Handle(ViewItems command)
        {
            return await _repo.GetAll();
        }
    }
}