namespace RPGCompanion.Domain.Model.Values
{
    using DomainCore;

    public class Name: DomainValueType
    {
        private string v;

        public Name(string v)
        {
            this.v = v;
        }

        string DisplayName { get; }
    }
}
