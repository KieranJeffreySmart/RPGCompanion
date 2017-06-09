namespace RPGCompanion.Domain.Model.Creature
{
    using System;
    using Values;

    public class Creature : NamedEntity<Guid>
    {
        public Creature(Guid id, Name name, Description description) : base(id, name, description)
        {
        }
    }
}