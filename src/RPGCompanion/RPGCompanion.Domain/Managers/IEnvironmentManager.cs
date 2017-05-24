namespace RPGCompanion.Domain.Managers
{
    using Model.Location;

    public interface IEnvironmentManager
    {
        LocalEnvironment Local { get; }
        GlobalEnvironment Global { get; }
    }
}
