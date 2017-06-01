namespace RPGCompanion.Domain.Model.Narrative
{
    using System;
    using Values;

    public class Scene: NamedEntity<Guid>
    {
        public Scene(Guid id, Name name, Description description) : base(id, name, description)
        {
        }
    }
}