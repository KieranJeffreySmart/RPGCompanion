using RPGCompanion.Domain.Model;
using System.Collections.Generic;
using RPGCompanion.Domain.Services;

namespace RPGCompanion.Domain.Abstract
{
    public class Entity
    {
        public Timeline Timeline;
        Name Name { get; }

        Character Character;
        private ITimelineManager timelineManager;
        private ICharacterManager characterManager;

        public Entity(Timeline timeline, Character character, Name name)
        {
            Timeline = timeline;
            Character = character;
            Name = name;
        }
    }
}
