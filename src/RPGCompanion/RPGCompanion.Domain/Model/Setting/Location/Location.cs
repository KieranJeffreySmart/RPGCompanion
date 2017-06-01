namespace RPGCompanion.Domain.Model.Setting.Location
{
    using System;
    using Values;

    public class Location: NamedEntity<Guid>
    {
        public Location(Guid id, Name name, Description description, Guid globalEnvironmentId) : base(id, name, description)
        {
            GlobalEnvironmentId = globalEnvironmentId;
        }

        public Guid GlobalEnvironmentId { get; }
    }
}
