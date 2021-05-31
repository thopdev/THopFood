using Bunit;
using ThopFood.Blazor.Components.Recipe;
using ThopFood.Blazor.Models;
using Xunit;
using static System.Guid;

namespace ThopFood.Blazor.BUnit.Components.Recipe
{
    public class RecipeTitleCardComponentTest : TestContext
    {
        [Fact]
        public void SkeletonLoadingTest()
        {
            var component = RenderComponent<RecipeTitleCardComponent>();

            Assert.Equal(4, component.FindAll(".mud-skeleton").Count);

            component.SetParametersAndRender((nameof(RecipeTitleCardComponent.Recipe), new RecipeModel()));
            Assert.Equal(0, component.FindAll(".mud-skeleton").Count);
        }

        [Fact]
        public void ValuesCorrectSetTest()
        {
            var title = NewGuid().ToString();
            var description = NewGuid().ToString();
            var imageUrl = NewGuid().ToString();

            var component = RenderComponent<RecipeTitleCardComponent>((nameof(RecipeTitleCardComponent.Recipe),
                new RecipeModel {Title = title, Description = description, ImageUrl = imageUrl}));

            Assert.Equal(title , component.Find(".mud-card-header-content > h6").TextContent);
            Assert.Equal(description, component.Find(".mud-card-header-content > p").TextContent);
        }
    }
}
