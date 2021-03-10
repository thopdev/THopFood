using ThopFood.Shared.Dtos.RecipeSteps;

namespace ThopFood.Shared.Dtos.Recipes
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        public string ImageUrl { get; set; }

        public bool Favorite { get; set; }

        public int[] IngredientIds { get; set; }

        public int[] UtensilIds { get; set; }

        public int OwnerId { get; set; }

        public RecipeStepDto[] Steps { get; set; }
    }
}
