namespace RPGCompanion.Application.Narrative
{
    using System;
    using System.Collections.Generic;
    using Domain;

    public class StartStory : DomainCommand<IEnumerable<Guid>>
    {
        public Guid MomentId { get; set; }
        public Guid EnvironmentId { get; set; }
        public Guid StoryId { get; set; }
        public Guid EnviroinmentId { get; set; }
        public Guid StroyId { get; set; }
    }
}