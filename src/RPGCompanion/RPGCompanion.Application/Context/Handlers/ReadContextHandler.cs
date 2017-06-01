namespace RPGCompanion.Application.Context.Handlers
{
    using System.Threading.Tasks;
    using Context;
    using Domain.Mediator;
    using RPGCompanion.Domain.Model.Context;
    using RPGCompanion.Domain.Repository;

    public class ReadContextHandler: IPrivateMessageHandler<ReadContext, Context>
    {
        private readonly IContextRepository _repo;

        public ReadContextHandler(IContextRepository repo)
        {
            _repo = repo;
        }

        public async Task<Context> Handle(ReadContext command)
        {
            return await _repo.Get(command.ContextId);
        }
    }
}