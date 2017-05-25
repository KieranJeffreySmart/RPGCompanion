namespace RPGCompanion.Application.Queries.Handlers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Model.Story;
    using Domain.Repository;
    using Mediator;

    public class GetStoriesHandler : IPrivateMessageHandler<GetStories, IEnumerable<Story>>
    {
        private readonly IStoryRepository _repo;

        public GetStoriesHandler(IStoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Story>> Handle(GetStories command)
        {
            return await _repo.Get();
        }
    }
}