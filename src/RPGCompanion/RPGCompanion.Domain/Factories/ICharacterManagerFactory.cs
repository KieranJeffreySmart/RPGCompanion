namespace RPGCompanion.Domain.Factories
{
    using Managers;

    public interface ICharacterManagerFactory
    {
        ICharacterManager Create();
    }
}
