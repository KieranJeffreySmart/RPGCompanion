namespace RPGCompanion.Application.Narrative
{
    using System;
    using System.Threading.Tasks;
    using Domain.Mediator;
    using RPGCompanion.Domain.Model.Narrative;
    using RPGCompanion.Domain.Repository;

    public class NewStoryHandler: IPrivateMessageHandler<NewStory, Guid>
    {
        private readonly IStoryRepository _repo;

        public NewStoryHandler(IStoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(NewStory command)
        {
            var id = Guid.NewGuid();
            await _repo.Insert(new Story(id, command.Name, command.Description));
            return id;
        }
    }
}