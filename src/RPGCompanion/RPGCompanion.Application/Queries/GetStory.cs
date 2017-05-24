namespace RPGCompanion.Application.Queries
{
    using System;
    using Domain.Model.Story;

    public class GetStory: DomainQuery<Story>
    {
        public Guid Id { get; set; }
    }
}