using RPGCompanion.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGCompanion.Domain.Repository
{
    using Model.Context.Types;
    using Model.Values;

    public interface IItemTypeRepository
    {
        ItemType Get(long itemTypeId);
        ItemType Get(Name name);
    }
}
