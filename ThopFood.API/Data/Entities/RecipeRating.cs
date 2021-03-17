namespace ThopFood.API.Data.Entities
{
    public class RecipeRating
    {
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int Rating { get; set; }
    }
}
