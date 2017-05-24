namespace RPGCompanion.Domain.Model.Character
{
    using System.Collections.Generic;
    using Values;

    public class ListTrait<TValue>: Trait
    {
        public ListTrait(Name name, List<TValue> values): base(name)
        {
            this.Values = values;
        }

        public List<TValue> Values { get; }
    }
}
