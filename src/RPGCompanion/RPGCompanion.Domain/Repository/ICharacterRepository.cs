using System.Collections.Generic;
using RPGCompanion.Domain.Model;

namespace RPGCompanion.Domain.Repository
{
    using Model.Character;
    using Model.Context;

    public interface ICharacterRepository
    {
        List<Character> GetAll(Context context);
    }
}
