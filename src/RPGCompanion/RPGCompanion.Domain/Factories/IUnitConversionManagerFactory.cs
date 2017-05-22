using System;
using System.Collections.Generic;
using System.Text;
using RPGCompanion.Domain.Model;

namespace RPGCompanion.Domain.Managers
{
    public interface IUnitConversionManagerFactory
    {
        IUnitConversionManager Create();
    }
}
