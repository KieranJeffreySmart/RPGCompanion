namespace RPGCompanion.Domain.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model.Context;
    using Model.Setting.Location;

    public interface IGlobalEnvironmentRepository
    {
        List<GlobalEnvironment> GetAll(Context context);
        Task<GlobalEnvironment> Get(Guid environmentId);
    }
}
