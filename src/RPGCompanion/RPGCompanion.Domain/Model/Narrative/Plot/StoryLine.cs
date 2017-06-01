namespace RPGCompanion.Domain.Model.Narrative.Plot
{
    using System;
    using Values;

    public class StoryLine: NamedEntity<Guid>
    {
        public StoryLine(Guid id, Name name, Description description) : base(id, name, description)
        {
        }
    }
}