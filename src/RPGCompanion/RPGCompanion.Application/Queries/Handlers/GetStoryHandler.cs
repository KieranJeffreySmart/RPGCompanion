namespace RPGCompanion.Application.Queries.Handlers
{
    using System.Threading.Tasks;
    using Domain.Model.Story;
    using Domain.Repository;
    using Mediator;

    public class GetStoryHandler: IPrivateMessageHandler<GetStory, Story>
    {
        private readonly IStoryRepository _repo;

        public GetStoryHandler(IStoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<Story> Handle(GetStory command)
        {
            return await _repo.Get(command.Id);
        }
    }
}