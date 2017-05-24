using System;
using System.Collections.Generic;
using System.Text;
using RPGCompanion.Domain.Model;

namespace RPGCompanion.Domain.Repository
{
    using Model.Context;
    using Model.Timeline;

    public interface IEventRepository
    {
        List<Event> GetAll(Context context);
    }
}
