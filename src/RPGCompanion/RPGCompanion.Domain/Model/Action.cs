using RPGCompanion.Domain.Abstract;
using System.Collections.Generic;

namespace RPGCompanion.Domain.Model
{
    public class Action : Activity
    {
        public Action(string description, Entity source, Entity target)
        {
            Description = description;
            Source = source;
            Target = target;
        }

        public string Description { get; }
        public Entity Source { get; }
        public Entity Target { get; }

        internal Action Clone()
        {
            return new Action(Description, Source, Target);
        }
    }
}
