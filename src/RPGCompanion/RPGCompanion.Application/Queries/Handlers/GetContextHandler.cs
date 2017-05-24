namespace RPGCompanion.Application.Queries.Handlers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Model.Context;
    using Domain.Repository;
    using Mediator;

    public class GetContextHandler: IPrivateMessageHandler<GetContext, Context>
    {
        private readonly IContextCollectionRepository _repo;

        public GetContextHandler(IContextCollectionRepository repo)
        {
            _repo = repo;
        }

        public async Task<Context> Handle(GetContext command)
        {
            var collection = await _repo.Get(command.CollectionId);

            return collection?.Contexts.FirstOrDefault(c => c.Id == command.ContextId);
        }
    }
}