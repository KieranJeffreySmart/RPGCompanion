using RPGCompanion.Domain.Abstract;
using RPGCompanion.Domain.Managers;
using System;

namespace RPGCompanion.Domain.Model
{
    public class Unit
    {
        int AtomicValue { get; }
        UnitType UnitType { get; }
        
        public Unit(UnitType unitType, int atomicValue)
        {
            UnitType = unitType;
            AtomicValue = atomicValue;
        }
    }
}
