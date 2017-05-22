using RPGCompanion.Domain.Abstract;

namespace RPGCompanion.Domain.Services
{
    public interface IEnvironmentManagerFactory
    {
        IEnvironmentManager Create();
    }
}
