using RPGCompanion.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using RPGCompanion.Domain.Abstract;

namespace RPGCompanion.Domain.Repository
{
    public interface IItemTypeRepository
    {
        ItemType Get(long itemTypeId);
        ItemType Get(Name name);
    }
}
