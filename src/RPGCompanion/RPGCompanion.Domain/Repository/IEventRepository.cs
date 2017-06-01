namespace RPGCompanion.Domain.Repository
{
    using System.Collections.Generic;
    using Model.Context;
    using Model.Setting.Timeline;

    public interface IEventRepository
    {
        List<Event> GetAll(Context context);
    }
}
