using System.Collections.Generic;
using RPGCompanion.Domain.Abstract;
using RPGCompanion.Domain.Model;

namespace RPGCompanion.Domain.Repository
{
    public interface ICharacterRepository
    {
        List<Character> GetAll(Context context);
    }
}
