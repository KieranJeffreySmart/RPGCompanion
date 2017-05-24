namespace RPGCompanion.Domain.Factories
{
    using System;
    using Model.GameEntities;
    using Model.Timeline;
    using Model.Values;
    using Repository;

    public class ItemFactory: IItemFactory
    {
        ITimelineManagerFactory _timelineManagerFactory;
        ICharacterManagerFactory _characterManagerFactory;
        IUnitConversionManagerFactory _unitConversionFactory;
        IUnitTypeRepository _unitTypeRepository;
        IItemTypeRepository _itemTypeRepository;

        public Item Create(long itemTypeId, int quantity)
        {
            var itemType = _itemTypeRepository.Get(itemTypeId);
            var unitType = _unitTypeRepository.Get(itemType.UnitTypeId);
            return new Item(new Thing(Guid.NewGuid(), new Timeline(), itemType.Character, new Name("thing")), new Unit(unitType, quantity));
        }
    }
}
