namespace RPGCompanion.Application
{
    using Domain;
    using RPGCompanion.Domain.Model.Values;

    public class NamedCommand : DomainCommand
    {
        public Name Name { get; set; }

        public Description Description { get; set; }
    }

    public class NamedCommand<T>: DomainCommand<T>
    {
        public Name Name { get; set; }

        public Description Description { get; set; }
    }
}