namespace RPGCompanion.Application.Commands.Handlers
{
    using System;
    using System.Threading.Tasks;
    using Domain.Model.Context;
    using Domain.Repository;
    using Mediator;

    public class NewContextHandler: IPrivateMessageHandler<NewContext, Guid>
    {
        private readonly IContextCollectionRepository _repo;

        public NewContextHandler(IContextCollectionRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(NewContext command)
        {
            var collection = await _repo.Get(command.CollectionId);

            if (collection == null)
            {
                return Guid.Empty;
            }

            var newId = Guid.NewGuid();
            collection.Contexts.Add(new Context(newId, command.Name));

            return newId;
        }
    }
}