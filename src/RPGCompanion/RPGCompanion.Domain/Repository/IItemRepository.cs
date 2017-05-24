using System;
using System.Collections.Generic;
using System.Text;
using RPGCompanion.Domain.Model;

namespace RPGCompanion.Domain.Repository
{
    using Model.Context;
    using Model.GameEntities;

    public interface IItemRepository
    {
        List<Item> GetAll(Context context);
    }
}
