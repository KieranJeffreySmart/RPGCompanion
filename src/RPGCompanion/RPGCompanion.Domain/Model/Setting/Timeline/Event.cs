namespace RPGCompanion.Domain.Model.Setting.Timeline
{
    using System;
    using Character;
    using Values;

    public class Event : Activity
    {
        protected Event(Guid id, Name name, Description description, CharacterEntity source) : base(id, name, description)
        {
            Source = source;
        }

        public CharacterEntity Source { get; }
    }
}
