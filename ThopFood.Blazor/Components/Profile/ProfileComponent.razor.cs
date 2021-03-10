using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using ThopFood.Blazor.Models;
using ThopFood.Blazor.Services.EndpointServices;

namespace ThopFood.Blazor.Components.Profile
{
    public partial class ProfileComponent
    {
        [Parameter]
        public int UserId { get; set; }

        [Inject] public IUserProfileService UserProfileService { get; set; }

        public bool Loaded => Profile != null;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Profile = await UserProfileService.GetUserProfileAsync(UserId);
        }


        public UserProfile Profile { get; set; }

        public void FollowButton()
        {
            Profile.Following = !Profile.Following;

            if (Profile.Following)
            {
                Profile.Followers++;
            }
            else
            {
                Profile.Followers--;
            }
        }

    }
}
