namespace RPGCompanion.Application.Setting.Handlers
{
    using System;
    using System.Threading.Tasks;
    using Domain.Mediator;
    using RPGCompanion.Domain.Model.Setting.Location;
    using RPGCompanion.Domain.Repository;

    public class NewGlobalEnvironmentHandler: IPrivateMessageHandler<NewGlobalEnvironment, Guid>
    {
        private readonly IGlobalEnvironmentRepository _repo;

        public NewGlobalEnvironmentHandler(IGlobalEnvironmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(NewGlobalEnvironment command)
        {
            var id = Guid.NewGuid();
            await _repo.Add(new GlobalEnvironment(id, command.Name, command.Description));

            return id;
        }
    }
}