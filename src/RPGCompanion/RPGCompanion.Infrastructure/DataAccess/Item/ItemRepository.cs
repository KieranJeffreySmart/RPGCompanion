namespace RPGCompanion.Infrastructure.DataAccess.Item
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Model.Item;
    using Domain.Repository;
    public class ItemRepository: IItemRepository
    {
        private readonly List<Item> _inMenoryStorage = new List<Item>();

        public Task Add(Item item)
        {
            _inMenoryStorage.Add(item);
            return Task.FromResult(0);
        }

        public Task<IEnumerable<Item>> GetAll()
        {
            return Task.FromResult<IEnumerable<Item>>(_inMenoryStorage);
        }
    }
}