namespace RPGCompanion.Domain.Model.Narrative
{
    using System;
    using System.Collections.Generic;
    using Setting.Location;
    using Setting.Timeline;
    using Values;

    public class Story: NamedEntity<Guid>
    {
        public Story(Guid id, Name name, Description description) : base(id, name, description)
        {
        }

        public Moment Moment { get; private set; }

        public GlobalEnvironment GlobalEnvironment { get; private set; }

        public ICollection<StorySetting> Settings { get; } = new List<StorySetting>();

        public void Start(StorySetting setting)
        {
            Moment = setting.Moment;
            GlobalEnvironment = setting.GlobalEnvironment;
            Settings.Add(setting);
        }

        public void SetScene(Scene scene)
        {
        }
    }
}