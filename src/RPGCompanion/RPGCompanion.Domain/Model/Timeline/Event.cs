namespace RPGCompanion.Domain.Model.Timeline
{
    using GameEntities;

    public class Event : Activity
    {
        public string Description { get; }
        public GameEntity Source { get; }
        public GameEntity Target { get; }

        internal Event Clone()
        {
            return new Event();
        }
    }
}
