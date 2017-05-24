﻿namespace RPGCompanion.Domain.Repository
{
    using System;
    using System.Threading.Tasks;
    using Model.Context;

    public interface IContextCollectionRepository
    {
        Task Insert(ContextCollection contextCollection);
        Task<ContextCollection> Get(Guid commandId);
    }
}