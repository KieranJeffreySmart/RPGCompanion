namespace RPGCompanion.Application.Setting.Handlers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Mediator;
    using RPGCompanion.Domain.Model.Setting.Location;
    using RPGCompanion.Domain.Repository;

    public class ViewGlobalEnvironmentsHandler: IPrivateMessageHandler<ViewGlobalEnvironments, IEnumerable<GlobalEnvironment>>
    {
        private readonly IGlobalEnvironmentRepository _repo;

        public ViewGlobalEnvironmentsHandler(IGlobalEnvironmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<GlobalEnvironment>> Handle(ViewGlobalEnvironments command)
        {
            return await _repo.GetAll();
        }
    }
}