namespace RPGCompanion.Domain.Model.DomainCore
{
    public class DomainEntity<TIdentity> where TIdentity : struct
    {
        public TIdentity Id { get; }

        public DomainEntity(TIdentity id)
        {
            Id = id;
        }
    }
}