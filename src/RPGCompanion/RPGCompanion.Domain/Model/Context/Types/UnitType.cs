namespace RPGCompanion.Domain.Model.Context.Types
{
    using DomainCore;
    using Values;

    public class UnitType : DomainEntity<long>
    {
        public UnitType(long id, Name name) : base(id)
        {
            Name = name;
        }

        public Name Name { get; }
    }
}
