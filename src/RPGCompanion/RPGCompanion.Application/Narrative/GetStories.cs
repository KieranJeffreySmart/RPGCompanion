namespace RPGCompanion.Application.Narrative
{
    using System.Collections.Generic;
    using Domain;
    using RPGCompanion.Domain.Model.Narrative;

    public class GetStories: DomainQuery<IEnumerable<Story>>
    {
        
    }
}