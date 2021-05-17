using FluentValidation;
using ThopFood.Shared.Requests.Ingredient;

namespace ThopFood.API.Validators.Ingredients
{
    public class NewIngredientRequestValidator : AbstractValidator<NewIngredientRequest>
    {
        public NewIngredientRequestValidator()
        {
            RuleFor(r => r.Name).NotNull().NotEmpty();
            RuleFor(r => r.Type).NotNull();
        }
    }
}
