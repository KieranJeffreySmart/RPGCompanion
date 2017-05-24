using System.Collections.Generic;
using RPGCompanion.Domain.Model;

namespace RPGCompanion.Domain.Repository
{
    using Model.Context;
    using Model.Timeline;

    public interface IActionRepository
    {
        List<Action> GetAll(Context context);
    }
}
