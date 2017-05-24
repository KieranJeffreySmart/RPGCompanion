namespace RPGCompanion.Domain.Model.GameEntities
{
    using System.Collections.Generic;
    using Context.Types;
    using Values;

    public class Container: Item
    {
        public Container(GameEntity entity, UnitType unitType, Unit contentCapacity) : base(entity, new Unit(unitType, 1))
        {
            ContentCapacity = contentCapacity;
        }

        public Unit ContentCapacity { get; }

        public List<Item> Content { get; }
    }
}
