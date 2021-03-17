using System.Collections.Generic;

namespace ThopFood.API.Data.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public int OwnerId { get; set; }
        public virtual User Owner { get; set; }

        public int DefaultServingSize { get; set; }
        public int PrepTime { get; set; }
        public int CookTime { get; set; }
        public int TotalTime { get; set; }

        public virtual ICollection<RecipeRating> Ratings { get; set; }

        public virtual ICollection<RecipeIngredient> Ingredients { get; set; }

        public virtual ICollection<RecipeStep> Steps { get; set; }

        public virtual ICollection<Utensil> Utensils { get; set; }

    }
}
