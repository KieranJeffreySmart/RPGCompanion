namespace RPGCompanion.Application.Commands.Handlers
{
    using System;
    using System.Threading.Tasks;
    using Domain.Model.Context;
    using Domain.Repository;
    using Mediator;

    public class NewContextCollectionHandler: IPrivateMessageHandler<NewContextCollection, Guid>
    {
        private readonly IContextCollectionRepository _repo;

        public NewContextCollectionHandler(IContextCollectionRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(NewContextCollection command)
        {
            var newId = Guid.NewGuid();
            await _repo.Insert(new ContextCollection(newId, command.Name, command.Contexts));

            return newId;
        }
    }
}