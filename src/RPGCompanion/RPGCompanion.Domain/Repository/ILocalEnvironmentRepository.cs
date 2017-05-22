using System;
using System.Collections.Generic;
using System.Text;
using RPGCompanion.Domain.Abstract;
using RPGCompanion.Domain.Model;

namespace RPGCompanion.Domain.Repository
{
    public interface ILocalEnvironmentRepository
    {
        List<LocalEnvironment> GetAll(Context context);
    }
}
