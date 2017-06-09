namespace RPGCompanion.Infrastructure.DataAccess.Context
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Model.Context;
    using Domain.Repository;

    public class ContextRepository : IContextRepository
    {
        private readonly List<Context> _inMenoryStorage = new List<Context>();
        public Task Add(Context context)
        {
            _inMenoryStorage.Add(context);
            return Task.CompletedTask;
        }

        public Task<Context> Get(Guid id)
        {
            return Task.FromResult(_inMenoryStorage.FirstOrDefault(e => e.Id == id));
        }

        public Task<IEnumerable<Context>> GetAll()
        {
            return Task.FromResult<IEnumerable<Context>>(_inMenoryStorage);
        }
    }
}