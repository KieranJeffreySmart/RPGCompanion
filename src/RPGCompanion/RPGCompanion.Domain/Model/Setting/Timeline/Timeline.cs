namespace RPGCompanion.Domain.Model.Setting.Timeline
{
    using System.Collections.Generic;

    public class Timeline
    {
        public Timeline(ICollection<Activity> activities)
        {
            Activities = activities;
        }

        public ICollection<Activity> Activities { get; }
    }
}
