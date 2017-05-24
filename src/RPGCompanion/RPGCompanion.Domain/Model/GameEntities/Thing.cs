namespace RPGCompanion.Domain.Model.GameEntities
{
    using System;
    using Character;
    using Timeline;
    using Values;

    public class Thing : GameEntity
    {
        public Thing(Guid id, Timeline timeline, Character character, Name name) : base(id, timeline, character, name)
        {
        }
    }
}
