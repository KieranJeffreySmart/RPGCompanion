namespace RPGCompanion.Domain.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model.Item;

    public interface IItemRepository
    {
        Task Add(Item item);

        Task<IEnumerable<Item>> GetAll();
    }
}