using RPGCompanion.Domain.Services;
using System;

namespace RPGCompanion.Domain.Abstract
{
    public class Location
    {
        private readonly IEnvironmentManager _environmentManager;

        public LocalEnvironment LocalEnvironment => _environmentManager.Local;
        public GlobalEnvironment GlobalEnvironment => _environmentManager.Global;
        public Location(IEnvironmentManager environmentManager)
        {
            _environmentManager = environmentManager;
        }
    }
}
