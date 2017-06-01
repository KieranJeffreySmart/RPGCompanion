namespace RPGCompanion.Domain.Model
{
    using Domain;
    using Values;

    public class NamedEntity<T>: DomainEntity<T> where T : struct
    {
        public NamedEntity(T id, Name name, Description description): base(id)
        {
            Name = name;
            Description = description;
        }

        public Name Name { get; }
        public Description Description { get; }
    }
}