using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThopFood.Blazor.Models.Recipe.Create
{
    public class CreateRecipeStep
    {
        [Required]
        public string Text { get; set; }
    }
}
