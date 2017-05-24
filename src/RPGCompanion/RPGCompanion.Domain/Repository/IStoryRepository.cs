namespace RPGCompanion.Domain.Repository
{
    using System;
    using System.Threading.Tasks;
    using Model.Story;

    public interface IStoryRepository
    {
        Task<Story> Get(Guid commandId);
        Task Insert(Story story);
    }
}