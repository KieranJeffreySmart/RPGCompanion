using System.Collections.Generic;
using RPGCompanion.Domain.Model;

namespace RPGCompanion.Domain.Repository
{
    using Model.Context;
    using Model.GameEntities;

    public interface ICreatureRepository
    {
        List<Creature> GetAll(Context context);
    }
}
