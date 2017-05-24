namespace RPGCompanion.Domain.Factories
{
    using Model.Timeline;

    public class EventFactory
    {
        Event _eventTemplate;

        public Event Create()
        {
            return _eventTemplate.Clone();
        }
    }
}
