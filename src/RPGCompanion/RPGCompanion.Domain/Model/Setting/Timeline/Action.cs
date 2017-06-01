namespace RPGCompanion.Domain.Model.Setting.Timeline
{
    using System;
    using Character;
    using Values;

    public class Action : Activity
    {
        protected Action(Guid id, Name name, Description description, CharacterEntity source, CharacterEntity target) : base(id, name, description)
        {
            Source = source;
            Target = target;
        }

        public CharacterEntity Source { get; }
        public CharacterEntity Target { get; }
    }
}
