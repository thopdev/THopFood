namespace ThopFood.Shared.Dtos.Recipes
{
    public class UpdateRecipeDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public int CookTime { get; set; }
        public int PrepTime { get; set; }
        public int TotalTime { get; set; }

        public int DefaultServingSize { get; set; }
    }
}
