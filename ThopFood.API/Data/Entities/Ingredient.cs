using ThopFood.Shared.Enums;

namespace ThopFood.API.Data.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public IngredientType Type { get; set; }
    }
}
