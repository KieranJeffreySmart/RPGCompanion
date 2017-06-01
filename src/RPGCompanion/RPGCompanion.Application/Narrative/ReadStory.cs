namespace RPGCompanion.Application.Narrative
{
    using System;
    using Domain;
    using RPGCompanion.Domain.Model.Narrative.Plot;

    public class ReadStory : DomainQuery<StoryLine>
    {
        public Guid StoryLineId { get; set; }
    }
}