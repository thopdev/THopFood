using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ThopFood.Blazor.Components.Rating
{
    public partial class StarRatingComponent
    {
        [Parameter] public int AmountOfStars { get; set; } = 5;

        [Parameter] public int Score { get; set; }

        [Parameter] public EventCallback<int> RatingChange { get; set; }


        public string GetIconType(int starIndex)
        {
            if (starIndex * 2 == Score + 1)
            {
                return Icons.Material.Outlined.StarHalf;
            }

            return starIndex * 2 <= Score ? Icons.Material.Outlined.Star : Icons.Material.Outlined.StarBorder;
        }

        public void OnStarClick(int i)
        {
            Score = i * 2;
            RatingChange.InvokeAsync(Score);
        }
    }
}