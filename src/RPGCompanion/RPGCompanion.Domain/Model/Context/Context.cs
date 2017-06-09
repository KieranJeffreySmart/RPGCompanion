namespace RPGCompanion.Domain.Model.Context
{
    using System;
    using System.Collections.Generic;
    using Types;
    using Values;

    public class Context: ContextEntity<Guid>
    {
        private readonly List<UnitType> _unitTypes = new List<UnitType>();
        private readonly List<CharacterType> _characterTypes = new List<CharacterType>();
        private readonly List<ItemType> _itemTypes = new List<ItemType>();
        
        public Context(Guid id, Name name, Description description, Creator creator) : base(id, name, description, creator)
        {
        }

        public IReadOnlyCollection<UnitType> UnitTypes => _unitTypes;
        public IReadOnlyCollection<CharacterType> CharacterTypes => _characterTypes;
        public IReadOnlyCollection<ItemType> ItemTypes => _itemTypes;

        public void AddUnitType(Name name, Description description)
        {
            _unitTypes.Add(new UnitType(name, description));
        }

        public void AddCharacterTypeTraits(CharacterType type)
        {
            _characterTypes.Add(type);
        }

        public void AddItemType(Name name, IEnumerable<TraitGroup> traits)
        {
            _itemTypes.Add(new ItemType(name, traits));
        }

        public void AddCharacterType(Name name, IEnumerable<TraitGroup> traits)
        {
            _characterTypes.Add(new CharacterType(name, traits));
        }
    }
}
