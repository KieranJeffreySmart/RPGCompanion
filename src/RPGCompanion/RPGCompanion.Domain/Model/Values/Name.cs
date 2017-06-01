namespace RPGCompanion.Domain.Model.Values
{
    using Domain;

    public class Name: DomainValueType
    {
        public Name(string displayName)
        {
            DisplayName = displayName;
        }

        public string DisplayName { get; }

        protected bool Equals(Name other)
        {
            return string.Equals(DisplayName, other.DisplayName);
        }

        public override int GetHashCode()
        {
            return (DisplayName != null ? DisplayName.GetHashCode() : 0);
        }
    }
}
