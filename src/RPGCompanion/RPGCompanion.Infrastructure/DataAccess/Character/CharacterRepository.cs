namespace RPGCompanion.Infrastructure.DataAccess.Character
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Model.Character;
    using Domain.Repository;

    public class CharacterRepository: ICharacterRepository
    {
        private readonly List<Character> _inMenoryStorage = new List<Character>();
        public Task Add(Character context)
        {
            _inMenoryStorage.Add(context);
            return Task.CompletedTask;
        }

        public Task<Character> Get(Guid id)
        {
            return Task.FromResult(_inMenoryStorage.FirstOrDefault(e => e.Id == id));
        }

        public Task<IEnumerable<Character>> GetAll()
        {
            return Task.FromResult<IEnumerable<Character>>(_inMenoryStorage);
        }
    }
}