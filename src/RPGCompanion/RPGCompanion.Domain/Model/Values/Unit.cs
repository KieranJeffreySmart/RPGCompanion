namespace RPGCompanion.Domain.Model.Values
{
    using Context.Types;
    using Domain;

    public class Unit: DomainValueType
    {
        public long Value { get; }
        public UnitType UnitType { get; }
        
        public Unit(UnitType unitType, long value)
        {
            UnitType = unitType;
            Value = value;
        }
    }
}
