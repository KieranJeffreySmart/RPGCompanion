namespace RPGCompanion.Application.Character.Handlers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Mediator;
    using Item;
    using RPGCompanion.Domain.Model.Character;
    using RPGCompanion.Domain.Model.Item;
    using RPGCompanion.Domain.Repository;

    public class ViewCharactersHandler : IPrivateMessageHandler<ViewCharacters, IEnumerable<Character>>
    {
        private ICharacterRepository _repo;

        public ViewCharactersHandler(ICharacterRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Character>> Handle(ViewCharacters command)
        {
            return await _repo.GetAll();
        }
    }
}