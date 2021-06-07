using FluentValidation;
using ThopFood.Shared.Requests.Utensil;

namespace ThopFood.API.Validators.Utensil
{
    public class CreateUtensilRequestValidator : AbstractValidator<CreateUtensilRequest>
    {
        public CreateUtensilRequestValidator()
        {
            RuleFor(r => r.Name).NotEmpty();
        }
    }
}
