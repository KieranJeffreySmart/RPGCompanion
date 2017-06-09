namespace RPGCompanion.Infrastructure.DataAccess.Story
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Model.Narrative;
    using Domain.Repository;

    public class StoryRepository: IStoryRepository
    {
        private readonly List<Story> _inMemoryStorage = new List<Story>();
        public Task<Story> Get(Guid id)
        {
            return Task.FromResult(_inMemoryStorage.FirstOrDefault(s => s.Id == id));
        }

        public Task Insert(Story story)
        {
            _inMemoryStorage.Add(story);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Story>> Get()
        {
            return Task.FromResult<IEnumerable<Story>>(_inMemoryStorage);
        }
    }
}