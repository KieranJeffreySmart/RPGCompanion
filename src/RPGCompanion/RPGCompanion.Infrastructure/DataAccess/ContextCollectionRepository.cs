namespace RPGCompanion.Infrastructure.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Model.Context;
    using Domain.Repository;

    public class ContextCollectionRepository: IContextCollectionRepository
    {
        private readonly List<ContextCollection> _inMenoryStorage = new List<ContextCollection>();
        public Task Insert(ContextCollection contextCollection)
        {
            _inMenoryStorage.Add(contextCollection);
            return Task.CompletedTask;
        }

        public Task<ContextCollection> Get(Guid id)
        {
            return Task.FromResult(_inMenoryStorage.FirstOrDefault(e => e.Id == id));
        }
    }
}