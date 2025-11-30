namespace PlanShare.App.Extensions;

public static class ApplicationExtensions
{
    extension(Application application)
    {
        private bool IsLightMode()
            => application.RequestedTheme == AppTheme.Light;

        public Color GetPrimaryColor()
        {
            var color = application.IsLightMode()
                ? "PRIMARY_COLOR_LIGHT"
                : "PRIMARY_COLOR_DARK";

            return (Color)Application.Current!.Resources[color];
        }

        public Color GetLineColor()
        {
            var color = application.IsLightMode()
                ? "LINES_COLOR_LIGHT"
                : "LINES_COLOR_DARK";

            return (Color)Application.Current!.Resources[color];
        }
    }
}