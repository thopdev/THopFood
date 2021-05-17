using System.ComponentModel.DataAnnotations;

namespace ThopFood.Blazor.Models
{
    public class RecipeStepModel
    {
        [Required]
        public string Text { get; set; }

    }
}
