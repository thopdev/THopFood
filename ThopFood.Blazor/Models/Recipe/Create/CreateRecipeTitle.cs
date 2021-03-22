using System.ComponentModel.DataAnnotations;

namespace ThopFood.Blazor.Models.Recipe.Create
{
    public class CreateRecipeTitle
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title should be at least 5 characters long")]
        public string Title { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Description should be at least 5 characters long")]
        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
