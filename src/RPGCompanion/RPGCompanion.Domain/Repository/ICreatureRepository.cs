namespace RPGCompanion.Domain.Repository
{
    using System.Collections.Generic;
    using Model.Creature;

    public interface ICreatureRepository
    {
        List<Creature> GetAll();
    }
}
