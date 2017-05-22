using System;
using System.Collections.Generic;
using System.Text;
using RPGCompanion.Domain.Abstract;

namespace RPGCompanion.Domain.Model
{
    public class Container: Item
    {
        public Container(Entity entity, UnitType unitType, Unit contentCapacity) : base(entity, new Unit(unitType, 1))
        {
            ContentCapacity = contentCapacity;
        }

        public Unit ContentCapacity { get; }

        public List<Item> Content { get; }
    }
}
