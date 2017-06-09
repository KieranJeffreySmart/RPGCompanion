namespace RPGCompanion.Application.Context.Handlers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Mediator;
    using RPGCompanion.Domain.Model.Context;
    using RPGCompanion.Domain.Repository;

    public class ViewContextsHandler: IPrivateMessageHandler<ViewContexts, IEnumerable<Context>>
    {
        private readonly IContextRepository _repo;

        public ViewContextsHandler(IContextRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Context>> Handle(ViewContexts command)
        {
            return await _repo.GetAll();
        }
    }
}