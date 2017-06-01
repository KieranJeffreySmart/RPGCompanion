namespace RPGCompanion.AcceptanceTests
{
    using Api.IoC;
    using Application.Domain.Mediator;
    using Application.Setting;
    using Domain.Model.Values;

    public class SettingAcceptanceTests
    {
        private NewGlobalEnvironment _openingEnvironment;
        private NewLocation _location;
        private IManagedMediator _mediator;

        public SettingAcceptanceTests()
        {
            var container = Bootstrapper.Bootstrap();
            _mediator = container.Resolve<IManagedMediator>();
        }


        private void AGlobalEnvironment()
        {
            _openingEnvironment = new NewGlobalEnvironment { Name = new Name("Fighting Fantasy") };
        }

        private void ALocation()
        {
            _location = new NewLocation { Name = new Name("Entrance to Firetop Mountain") };
        }
    }
}