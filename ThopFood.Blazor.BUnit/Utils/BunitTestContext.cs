using AutoFixture;
using AutoFixture.AutoMoq;
using Bunit;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using ThopFood.Blazor.Services.EndpointServices;
using VerifyTests;

namespace ThopFood.Blazor.BUnit.Utils
{
    public class BunitTestContext
    {
        protected TestContext Bunit { get; private set; }
        protected IFixture Fixture { get; private set; }

        public BunitTestContext()
        {
            Bunit = new TestContext();
            Fixture = new Fixture().Customize(new AutoMoqCustomization(){ConfigureMembers = true});

            RegisterServices();

            VerifyBunit.Initialize();
        }

        private void RegisterServices()
        {
            RegisterServiceMock<IUserProfileService>();
        }

        private void RegisterServiceMock<T>() where T : class
        {
            var service = Fixture.Freeze<Mock<T>>();
            Bunit.Services.TryAddSingleton(service.Object);
        }
    }
}