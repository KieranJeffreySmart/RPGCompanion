namespace RPGCompanion.Application.Commands.Handlers
{
    using System;
    using System.Threading.Tasks;
    using Domain.Model.Story;
    using Domain.Repository;
    using Mediator;
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
            await _repo.Insert(new Story(id, command.Name));
            return id;
        }
    }
}