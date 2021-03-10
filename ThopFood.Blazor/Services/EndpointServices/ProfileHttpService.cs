using System;
using System.Threading.Tasks;
using MudBlazor;
using ThopFood.Blazor.Models;
using ThopFood.Shared.Dtos.Users;

namespace ThopFood.Blazor.Services.EndpointServices
{
    public interface IUserProfileService
    {
        Task<UserProfile> GetUserProfileAsync(int id);
    }

    public class UserProfileHttpService : IUserProfileService
    {
        private const string ControllerEndpoint = "user";

        private readonly IHttpService _httpService;

        public UserProfileHttpService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<UserProfile> GetUserProfileAsync(int id)
        {
            var dto = await _httpService.GetAsync<UserDto>(ControllerEndpoint, id);
            return new UserProfile
            {
                Color = (Color) id,
                Name = dto.Name,
                UserName = dto.UserName,
                Following = dto.Following,
                Followers = dto.Followers,
                Rating = dto.Rating,
                RatingCount = dto.RatingCount
            };
        }
    }
}
