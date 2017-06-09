namespace RPGCompanion.Domain.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model.Setting.Location;

    public interface IGlobalEnvironmentRepository
    {
        Task Add(GlobalEnvironment environment);
        Task<IEnumerable<GlobalEnvironment>> GetAll();
        Task<GlobalEnvironment> Get(Guid environmentId);
    }
}
