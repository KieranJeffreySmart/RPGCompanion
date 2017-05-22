using RPGCompanion.Domain.Abstract;

namespace RPGCompanion.Domain.Model
{
    public class EventFactory
    {
        Event _eventTemplate;

        public Event Create()
        {
            return _eventTemplate.Clone();
        }
    }
}
