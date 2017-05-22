using RPGCompanion.Domain.Abstract;

namespace RPGCompanion.Domain.Services
{
    public interface IEnvironmentManager
    {
        LocalEnvironment Local { get; }
        GlobalEnvironment Global { get; }
    }
}
