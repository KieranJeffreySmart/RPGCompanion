using System;
using System.Collections.Generic;
using System.Text;
using RPGCompanion.Domain.Model;

namespace RPGCompanion.Domain.Repository
{
    public interface IItemRepository
    {
        List<Item> GetAll(Context context);
    }
}
