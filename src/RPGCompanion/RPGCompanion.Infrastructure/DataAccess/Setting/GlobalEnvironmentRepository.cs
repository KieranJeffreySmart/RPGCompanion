namespace RPGCompanion.Infrastructure.DataAccess.Setting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Model.Setting.Location;
    using Domain.Repository;

    public class GlobalEnvironmentRepository: IGlobalEnvironmentRepository
    {
        private readonly List<GlobalEnvironment> _inMemoryStorage = new List<GlobalEnvironment>();

        public Task Add(GlobalEnvironment environment)
        {
            _inMemoryStorage.Add(environment);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<GlobalEnvironment>> GetAll()
        {
            return Task.FromResult<IEnumerable<GlobalEnvironment>>(_inMemoryStorage);
        }

        public Task<GlobalEnvironment> Get(Guid environmentId)
        {
            return Task.FromResult(_inMemoryStorage.FirstOrDefault(e => e.Id == environmentId));
        }
    }
}