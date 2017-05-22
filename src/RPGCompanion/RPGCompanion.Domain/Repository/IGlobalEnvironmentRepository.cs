using System;
using System.Collections.Generic;
using System.Text;
using RPGCompanion.Domain.Abstract;
using RPGCompanion.Domain.Model;

namespace RPGCompanion.Domain.Repository
{
    public interface IGlobalEnvironmentRepository
    {
        List<GlobalEnvironment> GetAll(Context context);
    }
}
