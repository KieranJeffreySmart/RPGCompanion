namespace RPGCompanion.Domain.Model.Values
{
    using Domain;

    public class Description: DomainValueType
    {
        public Description(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}
