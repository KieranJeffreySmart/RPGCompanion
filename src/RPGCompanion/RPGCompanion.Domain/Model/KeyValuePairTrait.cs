using System.Collections.Generic;

namespace RPGCompanion.Domain.Abstract
{
    public class KeyValuePairTrait<TKey, TValue> : Trait
    {
        public KeyValuePairTrait(Name name, Dictionary<TKey, TValue> values) : base(name)
        {
            Values = values;
        }

        public Dictionary<TKey, TValue> Values { get; }
    }
}
