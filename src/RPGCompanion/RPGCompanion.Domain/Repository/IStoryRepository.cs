namespace RPGCompanion.Domain.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model.Narrative;

    public interface IStoryRepository
    {
        Task<Story> Get(Guid commandId);
        Task Insert(Story story);
        Task<IEnumerable<Story>> Get();
    }
}