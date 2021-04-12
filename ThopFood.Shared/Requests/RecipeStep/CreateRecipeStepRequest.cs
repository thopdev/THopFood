using System.ComponentModel.DataAnnotations;

namespace ThopFood.Shared.Requests.RecipeStep
{
    public class CreateRecipeStepRequest
    {
        [Required] 
        public string Text { get; set; }
    }
}
