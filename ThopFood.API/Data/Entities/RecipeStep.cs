namespace ThopFood.API.Data.Entities
{
    public class RecipeStep
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
