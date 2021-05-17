using ThopFood.Shared.Enums;

namespace ThopFood.Shared.Requests.Ingredient
{
    public class NewIngredientRequest
    {
        public string Name { get; set; }
        public IngredientType Type { get; set; }
    }
}
