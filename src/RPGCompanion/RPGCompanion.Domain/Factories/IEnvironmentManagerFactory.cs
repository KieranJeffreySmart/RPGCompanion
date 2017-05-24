namespace RPGCompanion.Domain.Factories
{
    using Managers;

    public interface IEnvironmentManagerFactory
    {
        IEnvironmentManager Create();
    }
}
