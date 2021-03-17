namespace ThopFood.API.Data.Entities
{
    public class RecipeIngredient
    {
        public int Id { get; set; }
        public double Amount { get; set; }

        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}