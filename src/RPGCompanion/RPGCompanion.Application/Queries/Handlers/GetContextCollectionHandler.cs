namespace RPGCompanion.Application.Queries.Handlers
{
    using System.Threading.Tasks;
    using Domain.Model.Context;
    using Domain.Repository;
    using Mediator;

    public class GetContextCollectionHandler: IPrivateMessageHandler<GetContextCollection, ContextCollection>
    {
        private readonly IContextCollectionRepository _repo;

        public GetContextCollectionHandler(IContextCollectionRepository repo)
        {
            _repo = repo;
        }

        public async Task<ContextCollection> Handle(GetContextCollection command)
        {
            return await _repo.Get(command.Id);
        }
    }
}