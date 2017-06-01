namespace RPGCompanion.Domain.Model.Context
{
    using System;
    using System.Collections.Generic;
    using Types;
    using Values;

    public class Context: ContextEntity<Guid>
    {
        readonly List<UnitType> _unitTypes = new List<UnitType>();

        public IReadOnlyCollection<UnitType> UnitTypes => _unitTypes;

        public Context(Guid id, Name name, Description description, Creator creator) : base(id, name, description, creator)
        {
        }

        public void AddUnitType(Name name, Description description)
        {
            _unitTypes.Add(new UnitType(name, description));
        }
    }
}
