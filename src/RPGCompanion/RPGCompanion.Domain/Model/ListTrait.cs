using System.Collections.Generic;

namespace RPGCompanion.Domain.Abstract
{
    public class ListTrait<TValue>: Trait
    {
        public ListTrait(Name name, List<TValue> values): base(name)
        {
            this.Values = values;
        }

        public List<TValue> Values { get; }
    }
}
