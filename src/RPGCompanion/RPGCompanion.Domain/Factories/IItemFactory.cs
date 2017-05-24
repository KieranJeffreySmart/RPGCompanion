namespace RPGCompanion.Domain.Factories
{
    using Model.GameEntities;

    public interface IItemFactory
    {
        Item Create(long itemTypeId, int quantity);
    }
}