using System.Collections.Generic;

namespace RPGCompanion.Domain.Abstract
{
    public abstract class Activity
    {
        IEnumerable<Event> Events { get; }
    }
}
