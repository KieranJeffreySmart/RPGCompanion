namespace RPGCompanion.Domain.Model.Setting.Location
{
    using System;
    using Domain;

    public class GlobalEnvironment: DomainEntity<Guid>
    {
        public GlobalEnvironment(Guid id) : base(id)
        {
        }
    }
}
