namespace RPGCompanion.Domain.Model.Context
{
    using Model;
    using Values;

    public class ContextEntity<T> : NamedEntity<T> where T : struct
    {
        public ContextEntity(T id, Name name, Description description, Creator creator) : base(id, name, description)
        {
            Creator = creator;
        }

        public Creator Creator { get; }
    }
}