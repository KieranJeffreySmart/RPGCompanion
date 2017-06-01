namespace RPGCompanion.Domain.Repository
{
    using System.Collections.Generic;
    using Model.Character;
    using Model.Context;

    public interface ICreatureRepository
    {
        List<Character> GetAll(Context context);
    }
}
