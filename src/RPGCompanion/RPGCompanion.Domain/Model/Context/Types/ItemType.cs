namespace RPGCompanion.Domain.Model.Context.Types
{
    using Character;
    using DomainCore;

    public class ItemType: DomainEntity<long>
    {
        public ItemType(int id, Character character, long unitTypeId) : base(id)
        {
            Character = character;
            UnitTypeId = unitTypeId;
        }

        public long UnitTypeId { get; internal set; }
        public Character Character { get; internal set; }
    }
}
