namespace RPGCompanion.Domain.Model
{
    public interface IItemFactory
    {
        Item Create(long itemTypeId, int quantity);
    }
}