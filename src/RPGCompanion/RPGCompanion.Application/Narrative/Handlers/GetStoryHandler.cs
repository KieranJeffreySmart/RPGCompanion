namespace RPGCompanion.Application.Narrative.Handlers
{
    using System.Threading.Tasks;
    using Domain.Mediator;
    using Narrative;
    using RPGCompanion.Domain.Model.Narrative;
    using RPGCompanion.Domain.Repository;

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