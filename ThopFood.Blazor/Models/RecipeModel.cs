﻿namespace ThopFood.Blazor.Models
{
    public class RecipeModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Favorite { get; set; }
        public RecipeIngredientId[] RecipeIngredientIds { get; set; }
    }
}
