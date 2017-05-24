namespace RPGCompanion.Domain.Model.Character
{
    using Values;

    public class Trait
    {
        public Name Name { get; }

        public Trait(Name name)
        {
            Name = name;
        }
    }
}
