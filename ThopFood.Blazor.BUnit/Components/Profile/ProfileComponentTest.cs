using System.Threading.Tasks;
using AutoFixture;
using Moq;
using ThopFood.Blazor.BUnit.Utils;
using ThopFood.Blazor.Components.Profile;
using ThopFood.Blazor.Models;
using ThopFood.Blazor.Services.EndpointServices;
using VerifyXunit;
using Xunit;

namespace ThopFood.Blazor.BUnit.Components.Profile
{
    [UsesVerify]
    public class ProfileComponentTest : BunitTestContext
    {
        [Fact]
        public async Task ShouldRenderUser_WhenUserIsPresent()
        {

            Fixture.Customize<UserProfile>(up => up
                .With(x => x.Name, "Thopdev")
                .With(x => x.Followers, 5)
                .With(x => x.Following, true)
                .With(x => x.UserName, "TEST")
                .With(x => x.RatingCount, 2456)
                .With(x => x.Rating, 2));

            var component = Bunit.RenderComponent<ProfileComponent>(c => c.Add(p => p.UserId, 5));

            await Verifier.Verify(component);

        }

        [Fact]
        public async Task ShouldRenderSkeleton_WhenNoUserIsPresent()
        {

            var userProfileMock = Fixture.Freeze < Mock<IUserProfileService>>();
            userProfileMock.Setup(x => x.GetUserProfileAsync(It.IsAny<int>())).ReturnsAsync((UserProfile) null);

            var component = Bunit.RenderComponent<ProfileComponent>(c => c.Add(p => p.UserId, 5));

            await Verifier.Verify(component);

        }
    }
}
