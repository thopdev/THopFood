using Microsoft.AspNetCore.Mvc;
using ThopFood.Shared.Dtos.Users;

namespace ThopFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public UserDto Index(int id)
        {
            return new UserDto
            {
                Id = id,
                UserName = "ThopDev",
                Name = "Thomas",
                Color = 5,
                Followers = 25,
                Following = true,
                Rating = 1,
                RatingCount = 1000000
            };
        }
    }
}
