using MudBlazor;

namespace ThopFood.Blazor.Models
{
    public class UserProfile
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public Color Color { get; set; }
        public int Followers { get; set; }
        public int Rating { get; set; }
        public int RatingCount { get; set; }
        public bool Following { get; set; }
    }
}