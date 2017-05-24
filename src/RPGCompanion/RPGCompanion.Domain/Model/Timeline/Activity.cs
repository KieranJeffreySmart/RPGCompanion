namespace RPGCompanion.Domain.Model.Timeline
{
    using System.Collections.Generic;

    public abstract class Activity
    {
        IEnumerable<Event> Events { get; }
    }
}
