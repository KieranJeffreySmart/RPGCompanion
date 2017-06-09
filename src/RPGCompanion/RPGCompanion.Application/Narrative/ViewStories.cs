namespace RPGCompanion.Application.Narrative
{
    using System.Collections.Generic;
    using Domain;
    using RPGCompanion.Domain.Model.Narrative;

    public class ViewStories: DomainQuery<IEnumerable<Story>>
    {
        
    }
}