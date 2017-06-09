namespace RPGCompanion.Domain.Model.Context
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Types;
    using Values;

    public class Context: NamedAggregate
    {
        private readonly List<UnitType> _unitTypes = new List<UnitType>();
        private readonly List<CharacterType> _characterTypes = new List<CharacterType>();
        private readonly List<ItemType> _itemTypes = new List<ItemType>();
        
        public Context(Guid id, Name name, Description description) : base(id, name, description)
        {
        }

        public IReadOnlyCollection<UnitType> UnitTypes => _unitTypes;
        public IReadOnlyCollection<CharacterType> CharacterTypes => _characterTypes;
        public IReadOnlyCollection<ItemType> ItemTypes => _itemTypes;

        public void AddUnitType(Name name, Description description)
        {
            _unitTypes.Add(new UnitType(name, description));
        }

        public void AddItemType(Name name, IEnumerable<TraitGroup> traits)
        {
            var traitList = traits.ToList();
            _itemTypes.Add(new ItemType(name, traitList));

            foreach (var unitType in traitList.SelectMany(tg => tg.Traits.Select(t => t.Value.UnitType)))
            {
                if (_unitTypes.Any(ut => ut.Name == unitType.Name))
                {
                    continue;
                }

                AddUnitType(unitType.Name, unitType.Description);
            }
        }

        public void AddCharacterType(Name name, IEnumerable<TraitGroup> traits)
        {
            var traitList = traits.ToList();
            _characterTypes.Add(new CharacterType(name, traitList));

            foreach (var unitType in traitList.SelectMany(tg => tg.Traits.Select(t => t.Value.UnitType)))
            {
                if (_unitTypes.Any(ut => ut.Name == unitType.Name))
                {
                    continue;
                }

                AddUnitType(unitType.Name, unitType.Description);
            }
        }
    }
}
