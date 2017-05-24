namespace RPGCompanion.Domain.Model.GameEntities
{
    using System;
    using Character;
    using DomainCore;
    using Managers;
    using Timeline;
    using Values;

    public class GameEntity: DomainEntity<Guid>
    {
        public Timeline Timeline;
        Name Name { get; }

        Character Character;
        private ITimelineManager timelineManager;
        private ICharacterManager characterManager;

        public GameEntity(Guid id, Timeline timeline, Character character, Name name): base(id)
        {
            Timeline = timeline;
            Character = character;
            Name = name;
        }
    }
}
