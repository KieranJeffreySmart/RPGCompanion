namespace RPGCompanion.Domain.Repository
{
    using System.Collections.Generic;
    using Model.Context;
    using Model.Setting.Timeline;

    public interface IActionRepository
    {
        List<Action> GetAll(Context context);
    }
}
