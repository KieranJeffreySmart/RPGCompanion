using RPGCompanion.Domain.Abstract;
using RPGCompanion.Domain.Managers;
using RPGCompanion.Domain.Repository;
using RPGCompanion.Domain.Services;

namespace RPGCompanion.Domain.Model
{
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
            return new Item(new Thing(new Timeline(), itemType.Character, new Name("thing")), new Unit(unitType, quantity));
        }
    }
}
