using MudBlazor;

namespace ThopFood.Blazor.Shared
{
    public partial class MainLayout
    {
        public MudTheme MudTheme = new MudTheme
        {
            Palette = new Palette
            {
                Primary = "#8FC93A",
                AppbarBackground = "#8FC93A",
                Secondary = "#508CA4",
                Background = "#F6FAFA",
                BackgroundGrey = "#F0F7F4"
            }
        };

        private bool _drawerOpen = true;

        public void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }
    }
}
