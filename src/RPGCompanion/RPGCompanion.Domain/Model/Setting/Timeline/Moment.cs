namespace RPGCompanion.Domain.Model.Setting.Timeline
{
    using System;
    using Values;

    public class Moment: NamedEntity<Guid>
    {
        public Moment(Guid id, Name name, Description description) : base(id, name, description)
        {
        }
    }
}