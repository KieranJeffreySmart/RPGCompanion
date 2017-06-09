namespace RPGCompanion.AcceptanceTests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Api.IoC;
    using Application.Domain.Mediator;
    using Application.Setting;
    using Domain.Model.Values;
    using FluentAssertions;
    using TestStack.BDDfy;
    using Xunit;

    public class SettingAcceptanceTests
    {
        private NewGlobalEnvironment _globalEnvironment;
        private IManagedMediator _mediator;
        private Guid _environmentId;

        public SettingAcceptanceTests()
        {
            var container = Bootstrapper.Bootstrap();
            _mediator = container.Resolve<IManagedMediator>();
        }

        [Fact]
        public void CreateAGlobalEnvironment()
        {
            this.Given(t => t.AGlobalEnvironment())
                .When(t => t.TheEnvironmentIsCreated().Wait())
                .Then(t => t.AllEnvironmentsCanBeViewed().Wait())
                .BDDfy();
        }

        public async Task TheEnvironmentIsCreated()
        {
            var response = await _mediator.Send(_globalEnvironment);
            response.Should().NotBeNull();
            _environmentId = response.Result;
            _environmentId.Should().NotBeEmpty();
        }

        private async Task AllEnvironmentsCanBeViewed()
        {
            var response = await _mediator.Send(new ViewGlobalEnvironments());
            response.Should().NotBeNull();

            var result = response.Result.ToList();
            result.Should().NotBeNull();
            result.Select(i => i.Id).Single().Should().Be(_environmentId);
            result.Select(i => i.Name).Single().Should().Be(_globalEnvironment.Name);
        }

        private void AGlobalEnvironment()
        {
            _globalEnvironment = new NewGlobalEnvironment { Name = new Name("Fighting Fantasy world") };
        }
    }
}