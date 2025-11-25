#if IOS
using PlanShare.App.Handlers;
#endif
using PlanShare.App.Constants;
using PlanShare.App.Navigation;
using PlanShare.App.Views.Pages.Login.DoLogin;
using PlanShare.App.Views.Pages.User.Register;

namespace PlanShare.App.Extensions;

public static class MauiAppBuilderExtensions
{
    extension(MauiAppBuilder builder)
    {
        public MauiAppBuilder ConfigurePages()
        {
            Routing.RegisterRoute(RoutePages.LoginPage, typeof(DoLoginPage));
            Routing.RegisterRoute(RoutePages.UserRegisterAccountPage, typeof(RegisterUserAccountPage));

            return builder;
        }

        public MauiAppBuilder ConfigureMauiFonts()
        {
            builder.ConfigureFonts(fonts =>
            {
                fonts.AddFont("Raleway-Black.ttf", FontFamily.MainFontBlack);
                fonts.AddFont("Raleway-Regular.ttf", FontFamily.MainFontRegular);
                fonts.AddFont("Raleway-Light.ttf", FontFamily.MainFontLight);
                fonts.AddFont("WorkSans-Black.ttf", FontFamily.SecondaryFontBlack);
                fonts.AddFont("WorkSans-Regular.ttf", FontFamily.SecondaryFontRegular);
            });

            return builder;
        }

        public MauiAppBuilder ConfigurePlatformHandlers()
        {
            builder.ConfigureMauiHandlers(handlers =>
            {
#if IOS
                handlers.AddHandler<Entry, CustomEntryHandler>();
#endif

#if Android
                // Android handlers
#endif
            });
            return builder;
        }
    }
}