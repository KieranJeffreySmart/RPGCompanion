namespace RPGCompanion.Domain.Factories
{
    using Model.GameEntities;

    public class CreatureFactory
    {
        private readonly Creature _creatureTemplate;

        public CreatureFactory(Creature creatureTemplate)
        {
            _creatureTemplate = creatureTemplate;
        }

        public Creature Create()
        {
            return _creatureTemplate.Clone();
        }
    }
}
