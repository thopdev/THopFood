using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunit;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MudBlazor;
using ThopFood.Blazor.Components.Profile;
using ThopFood.Blazor.Models;
using ThopFood.Blazor.Services.EndpointServices;
using Xunit;

namespace ThopFood.Blazor.BUnit.Components.Profile
{
    public class ProfileComponentTest : TestContext
    {
        private readonly Mock<IUserProfileService> _userProfileServiceMock;

        public ProfileComponentTest()
        {
            _userProfileServiceMock = new Mock<IUserProfileService>();
            Services.AddSingleton(_userProfileServiceMock.Object);
        }
        
        [Fact]
        public void FollowCountShouldBeAdjusted_WhenFollowButtonClicked()
        {
            _userProfileServiceMock.Setup(x => x.GetUserProfileAsync(1)).ReturnsAsync(new UserProfile
            {
                Followers = 5,
                Following = false,
                Color = Color.Dark,
                Name = Guid.NewGuid().ToString(),
                UserName = Guid.NewGuid().ToString()
            });

            var sut = RenderComponent<ProfileComponent>(x => x.Add(p => p.UserId, 1));

            var followerCountElement = sut.Find("[data-followers]");
            var button = sut.Find("button");

            followerCountElement.TextContent.Should().StartWith("5").And.EndWith("Followers");
            button.TextContent.Should().Be("Follow");
            button.Click();

            followerCountElement.TextContent.Should().StartWith("6").And.EndWith("Followers");
            button.TextContent.Should().Be("Following");

            button.Click();
            followerCountElement.TextContent.Should().StartWith("5").And.EndWith("Followers");
            button.TextContent.Should().Be("Follow");
        }
    }
}