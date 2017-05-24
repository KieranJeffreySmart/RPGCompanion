namespace RPGCompanion.Domain.Model.Values
{
    using Context.Types;
    using DomainCore;

    public class Unit: DomainValueType
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
