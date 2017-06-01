namespace RPGCompanion.Domain.Repository
{
    using Model.Context.Types;

    public interface IUnitTypeRepository
    {
        UnitType Get(long unitTypeId);
    }
}
