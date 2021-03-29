using System.ComponentModel.DataAnnotations;

namespace ThopFood.Blazor.Models.Recipe.Create
{
    public class CreateRecipeDescription
    {
        [Range(1, int.MaxValue, ErrorMessage = "The serving size must be greater than {1}.")] 
        public int DefaultServingSize { get; set; }

        public int PrepTime { get; set; }

        public int CookTime { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The serving size must be greater than {1}.")]
        public int TotalTime { get; set; }
    }
}