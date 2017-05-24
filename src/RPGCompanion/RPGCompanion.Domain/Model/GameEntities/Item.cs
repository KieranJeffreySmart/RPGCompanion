namespace RPGCompanion.Domain.Model.GameEntities
{
    using Values;

    public class Item
    {
        public Item(GameEntity entity, Unit quantity)
        {
            this.Of = entity;
            this.Quantity = quantity;
        }

        GameEntity Of { get; }
        Unit Quantity { get; }
    }
}
