namespace RPGCompanion.Domain.Model.Context.Types
{
    using Domain;
    using Values;

    public class UnitType : DomainValueType
    {
        public UnitType(Name name, Description description)
        {
            Name = name;
            Description = description;
        }

        public Name Name { get; }

        public Description Description { get; }
    }
}
