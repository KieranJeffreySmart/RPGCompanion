namespace RPGCompanion.Domain.Model.Setting.Location
{
    using System;
    using Domain;
    using Values;

    public class GlobalEnvironment: NamedEntity<Guid>
    {
        public GlobalEnvironment(Guid id, Name name, Description description) : base(id, name, description)
        {
        }
    }
}
