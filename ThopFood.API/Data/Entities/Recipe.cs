using System.ComponentModel.DataAnnotations;
using ThopFood.Shared.Dtos.Recipes;
namespace ThopFood.API.Data.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool Favorite { get; set; }

        public int OwnerId { get; set; }
    }
}
