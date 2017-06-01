namespace RPGCompanion.Domain.Model.Context
{
    using Domain;
    using Values;

    public class Trait: DomainValueType
    {
        public Name Name { get; }

        public Unit Value { get; }

        public Trait(Name name, Unit value)
        {
            Name = name;
            Value = value;
        }
    }
}
