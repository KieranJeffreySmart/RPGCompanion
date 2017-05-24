using System;
using System.Collections.Generic;
using System.Text;
using RPGCompanion.Domain.Model;

namespace RPGCompanion.Domain.Repository
{
    using Model.Context;
    using Model.Location;

    public interface IGlobalEnvironmentRepository
    {
        List<GlobalEnvironment> GetAll(Context context);
    }
}
