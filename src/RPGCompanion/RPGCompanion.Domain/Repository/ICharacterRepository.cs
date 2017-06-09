namespace RPGCompanion.Domain.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model.Character;

    public interface ICharacterRepository
    {
        Task Add(Character character);

        Task<IEnumerable<Character>> GetAll();
    }
}