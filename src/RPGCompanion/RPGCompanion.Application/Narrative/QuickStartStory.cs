namespace RPGCompanion.Application.Narrative
{
    using System;
    using System.Collections.Generic;
    using Domain;
    using Setting;

    public class QuickStartStory : DomainCommand<IEnumerable<Guid>>
    {
        public Guid ContextId { get; set; }
        public NewGlobalEnvironment Environment { get; set; }
        public NewStory Story { get; set; }
        public NewMoment Moment { get; set; }
        public StartStory Start { get; set; }
    }
}