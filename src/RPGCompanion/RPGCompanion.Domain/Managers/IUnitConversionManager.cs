using System;
using System.Collections.Generic;
using System.Text;
using RPGCompanion.Domain.Model;

namespace RPGCompanion.Domain.Managers
{
    public interface IUnitConversionManager
    {
        float Convert(Unit unit1, Unit unit2);
    }
}
