namespace RPGCompanion.Domain.Model.Values
{
    using DomainCore;

    public class Name: DomainValueType
    {
        public Name(string displayName)
        {
            DisplayName = displayName;
        }

        public string DisplayName { get; }
    }
}
