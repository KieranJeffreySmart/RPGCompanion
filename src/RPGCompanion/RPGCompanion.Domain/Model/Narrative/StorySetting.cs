namespace RPGCompanion.Domain.Model.Narrative
{
    using System;
    using Setting.Location;
    using Setting.Timeline;
    using Values;

    public class StorySetting: NamedEntity<Guid>
    {
        public StorySetting(Guid id, Name name, Description description, Moment moment, GlobalEnvironment globalEnvironment) : base(id, name, description)
        {
            Moment = moment;
            GlobalEnvironment = globalEnvironment;
        }

        public Moment Moment { get; }

        public GlobalEnvironment GlobalEnvironment { get; }
    }
}