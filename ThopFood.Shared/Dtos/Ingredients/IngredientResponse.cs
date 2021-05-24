using ThopFood.Shared.Enums;

namespace ThopFood.Shared.Dtos.Ingredients
{
    public class IngredientResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IngredientType Type { get; set; }
    }
}
