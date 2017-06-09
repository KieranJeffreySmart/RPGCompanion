namespace RPGCompanion.Application.Narrative.Handlers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Mediator;
    using Narrative;
    using RPGCompanion.Domain.Model.Narrative;
    using RPGCompanion.Domain.Repository;

    public class ViewStoriesHandler : IPrivateMessageHandler<ViewStories, IEnumerable<Story>>
    {
        private readonly IStoryRepository _repo;

        public ViewStoriesHandler(IStoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Story>> Handle(ViewStories command)
        {
            return await _repo.Get();
        }
    }
}