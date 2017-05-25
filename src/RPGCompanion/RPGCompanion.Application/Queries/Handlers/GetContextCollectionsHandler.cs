namespace RPGCompanion.Application.Queries.Handlers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Model.Context;
    using Domain.Repository;
    using Mediator;

    public class GetContextCollectionsHandler : IPrivateMessageHandler<GetContextCollections,
        IEnumerable<ContextCollection>>
    {
        private readonly IContextCollectionRepository _repo;

        public GetContextCollectionsHandler(IContextCollectionRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ContextCollection>> Handle(GetContextCollections command)
        {
            return await _repo.Get();
        }
    }
}