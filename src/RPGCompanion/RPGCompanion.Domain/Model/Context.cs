using RPGCompanion.Domain.Abstract;
using RPGCompanion.Domain.Repository;
using System.Collections.Generic;

namespace RPGCompanion.Domain.Model
{
    public class Context
    {
        ICharacterRepository _characterRepository;
        IItemRepository _itemRepository;
        IActionRepository _actionRepository;
        IEventRepository _eventRepository;
        ICreatureRepository _creatureRepository;
        ILocalEnvironmentRepository _localEnvironmentRepository;
        IGlobalEnvironmentRepository _globalEnvironmentRepository;
        ILocationRepository _locationRepository;

        public Name Name { get; }
        public Description Description { get; }

        public List<Character> Characters { get; }
        public List<UnitType> UnitTypes { get; }
        public List<ItemType> ItemTypes { get; }
        public List<Item> Items { get; }
        public List<Thing> Things { get; }
        public List<Action> Actions { get; }
        public List<Event> Events { get; }
        public List<Creature> Creatures { get; }
        public List<LocalEnvironment> LocalEnvironments { get; }
        public List<GlobalEnvironment> GlobalEnvironments { get; }
        public List<Location> Locations { get; }

        public Context(Name name)
        {
            Name = name;
            Characters = _characterRepository.GetAll(this);
            Items = _itemRepository.GetAll(this);
            Actions = _actionRepository.GetAll(this);
            Events = _eventRepository.GetAll(this);
            Creatures = _creatureRepository.GetAll(this);
            LocalEnvironments = _localEnvironmentRepository.GetAll(this);
            GlobalEnvironments = _globalEnvironmentRepository.GetAll(this);
            Locations = _locationRepository.GetAll(this);
        }
    }
}
