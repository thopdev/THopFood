﻿using Bunit;
using Bunit.Rendering;
using ThopFood.Blazor.Components.Rating;
using Xunit;

namespace ThopFood.Blazor.BUnit.Components.Rating
{
    public class StarRatingComponentTest : TestContext
    {
        [Theory]
        [InlineData(5)]
        [InlineData(3)]
        public void AmountOfStarTest(int starCount)
        {
            var component = RenderComponent<StarRatingComponent>(ComponentParameter.CreateParameter(nameof(StarRatingComponent.AmountOfStars), starCount));

            Assert.Equal(starCount, component.FindAll("svg").Count);

        }
        
        [Fact]
        public void DefaultStar()
        {
            var component = RenderComponent<StarRatingComponent>();

            Assert.Equal(5, component.FindAll("svg").Count);
        }
    }
}
