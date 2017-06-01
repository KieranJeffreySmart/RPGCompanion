namespace RPGCompanion.Domain.Repository
{
    using System.Collections.Generic;
    using Model.Context;
    using Model.Setting.Location;

    public interface ILocationRepository
    {
        List<Location> GetAll(Context context);
    }
}
