namespace RPGCompanion.Domain.Abstract
{
    public class Event : Activity
    {
        public string Description { get; }
        public Entity Source { get; }
        public Entity Target { get; }

        internal Event Clone()
        {
            return new Event();
        }
    }
}
