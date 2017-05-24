namespace RPGCompanion.Domain.Model.Timeline
{
    using GameEntities;

    public class Action : Activity
    {
        public Action(string description, GameEntity source, GameEntity target)
        {
            Description = description;
            Source = source;
            Target = target;
        }

        public string Description { get; }
        public GameEntity Source { get; }
        public GameEntity Target { get; }

        internal Action Clone()
        {
            return new Action(Description, Source, Target);
        }
    }
}
