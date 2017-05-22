using RPGCompanion.Domain.Abstract;

namespace RPGCompanion.Domain.Model
{
    public class Item
    {
        public Item(Entity entity, Unit quantity)
        {
            this.Of = entity;
            this.Quantity = quantity;
        }

        Entity Of { get; }
        Unit Quantity { get; }
    }
}
