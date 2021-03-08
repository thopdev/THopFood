using MudBlazor;
using ThopFood.Blazor.Models;

namespace ThopFood.Blazor.Components.Profile
{
    public partial class ProfileComponent
    {
        public UserProfile Profile { get; set; } = new UserProfile
        {
            Color = Color.Primary,
            Name = "Thomas",
            UserName = "@ThopDev",
            Followers = 425,
            Rating = 4,
            RatingCount = 10000,
            Following= true
        };



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
