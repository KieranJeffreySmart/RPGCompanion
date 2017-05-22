using System.Collections.Generic;
using RPGCompanion.Domain.Model;

namespace RPGCompanion.Domain.Repository
{
    public interface ICreatureRepository
    {
        List<Creature> GetAll(Context context);
    }
}
