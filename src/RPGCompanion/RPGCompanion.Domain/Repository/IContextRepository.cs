namespace RPGCompanion.Domain.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model.Context;

    public interface IContextRepository
    {
        Task Insert(Context contextCollection);
        Task<Context> Get(Guid commandId);
        Task<IEnumerable<Context>> Get();
    }
}