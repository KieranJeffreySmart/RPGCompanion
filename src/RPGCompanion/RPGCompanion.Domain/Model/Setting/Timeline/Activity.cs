namespace RPGCompanion.Domain.Model.Setting.Timeline
{
    using System;
    using Values;

    public abstract class Activity: NamedEntity<Guid>
    {
        protected Activity(Guid id, Name name, Description description) : base(id, name, description)
        {
        }
    }
}
