namespace RPGCompanion.Application.Narrative
{
    using System;
    using Domain;

    public class SetScene : DomainCommand<Guid>
    {
        public Guid StoryId { get; set; }
        public Guid LocationId { get; set; }
    }
}