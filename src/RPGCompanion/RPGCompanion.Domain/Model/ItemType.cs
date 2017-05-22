using RPGCompanion.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGCompanion.Domain.Model
{
    public class ItemType: LookupEntity
    {
        public ItemType(int id, Character character, long unitTypeId) : base(id)
        {
            Character = character;
            UnitTypeId = unitTypeId;
        }

        public long UnitTypeId { get; internal set; }
        public Character Character { get; internal set; }
    }
}
