using RPGCompanion.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGCompanion.Domain.Repository
{
    using Model.Context.Types;

    public interface IUnitTypeRepository
    {
        UnitType Get(long unitTypeId);
    }
}
