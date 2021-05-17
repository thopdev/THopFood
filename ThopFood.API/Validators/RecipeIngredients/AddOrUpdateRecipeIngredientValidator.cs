using FluentValidation;
using ThopFood.Shared.Requests.RecipeIngredient;

namespace ThopFood.API.Validators.RecipeIngredients
{
    public class AddOrUpdateRecipeIngredientValidator : AbstractValidator<AddOrUpdateRecipeIngredientRequest>
    {
        public AddOrUpdateRecipeIngredientValidator()
        {
            RuleFor(fv => fv.Amount).NotEmpty();
        }
    }
}