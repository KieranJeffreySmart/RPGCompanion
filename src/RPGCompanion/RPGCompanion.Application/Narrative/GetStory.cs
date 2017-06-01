namespace RPGCompanion.Application.Narrative
{
    using System;
    using Domain;
    using RPGCompanion.Domain.Model.Narrative;

    public class GetStory: DomainQuery<Story>
    {
        public Guid Id { get; set; }
    }
}