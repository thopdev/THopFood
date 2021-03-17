using System.Collections.Generic;

namespace ThopFood.API.Data.Entities
{
    public class Utensil
    {
        public int  Id { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
