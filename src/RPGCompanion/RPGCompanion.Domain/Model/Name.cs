namespace RPGCompanion.Domain.Abstract
{
    public class Name
    {
        private string v;

        public Name(string v)
        {
            this.v = v;
        }

        string DisplayName { get; }
    }
}
