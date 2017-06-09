namespace RPGCompanion.Application.Character.Handlers
{
    using System;
    using System.Threading.Tasks;
    using Domain.Mediator;
    using RPGCompanion.Domain.Model.Character;
    using RPGCompanion.Domain.Repository;

    public class CreateCharacterHander : IPrivateMessageHandler<CreateCharacter, Guid>
    {
        private readonly ICharacterRepository _repo;

        public CreateCharacterHander(ICharacterRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(CreateCharacter command)
        {
            var id = Guid.NewGuid();
            await _repo.Add(new Character(id, command.Name, command.Description, command.Traits));
            return id;
        }
    }
}