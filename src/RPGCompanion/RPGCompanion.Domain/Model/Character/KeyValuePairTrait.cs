namespace RPGCompanion.Domain.Model.Character
{
    using System.Collections.Generic;
    using Values;

    public class KeyValuePairTrait<TKey, TValue> : Trait
    {
        public KeyValuePairTrait(Name name, Dictionary<TKey, TValue> values) : base(name)
        {
            Values = values;
        }

        public Dictionary<TKey, TValue> Values { get; }
    }
}
