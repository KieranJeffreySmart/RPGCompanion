using System;
using System.Collections.Generic;
using System.Text;
using RPGCompanion.Domain.Abstract;
using RPGCompanion.Domain.Model;

namespace RPGCompanion.Domain.Repository
{
    public interface IEventRepository
    {
        List<Event> GetAll(Context context);
    }
}
