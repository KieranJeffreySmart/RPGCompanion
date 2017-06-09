namespace RPGCompanion.Application.Context.Handlers
{
    using System;
    using System.Threading.Tasks;
    using Domain.Mediator;
    using RPGCompanion.Domain.Model.Context;
    using RPGCompanion.Domain.Repository;

    public class CreateContextHandler: IPrivateMessageHandler<CreateContext, Guid>
    {
        private readonly IContextRepository _repo;

        public CreateContextHandler(IContextRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(CreateContext command)
        {
            var newId = Guid.NewGuid();
            await _repo.Add(new Context(newId, command.Name, command.Description, command.Creator));
            return newId;
        }
    }
}