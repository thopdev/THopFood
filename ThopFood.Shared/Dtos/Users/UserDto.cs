namespace ThopFood.Shared.Dtos.Users
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string UserName { get; set; }

        public int Color { get; set; }

        public int Followers { get; set; }
        public bool Following { get; set; }

        public int Rating { get; set; }
        public int RatingCount { get; set; }
    }
}
