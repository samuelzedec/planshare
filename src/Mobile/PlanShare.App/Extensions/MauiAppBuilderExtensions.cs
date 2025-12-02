using CommunityToolkit.Maui;
using PlanShare.App.Constants;
using PlanShare.App.Navigation;
using PlanShare.App.Resources.Styles.Handlers;
using PlanShare.App.ViewModels.Pages.Login.DoLogin;
using PlanShare.App.ViewModels.Pages.OnBoarding;
using PlanShare.App.ViewModels.Pages.User.Register;
using PlanShare.App.Views.Pages.Login.DoLogin;
using PlanShare.App.Views.Pages.User.Register;

namespace PlanShare.App.Extensions;

public static class MauiAppBuilderExtensions
{
    extension(MauiAppBuilder builder)
    {
        public MauiAppBuilder ConfigurePages()
        {
            // Routing.RegisterRoute(RoutePages.LoginPage, typeof(DoLoginPage));
            // Routing.RegisterRoute(RoutePages.UserRegisterAccountPage, typeof(RegisterUserAccountPage));

            // Faz o registro da Página com rota e ainda faz com que seja cadastrado
            // na injeção de dependencia a ViewModel
            // O Scoped E Singleton funcionam quase da msm forma no mobile
            // Então aqui podemos usar o Transient
            builder.Services.AddTransient<OnBoardingViewModel>();
            builder.Services.AddTransientWithShellRoute<DoLoginPage, DoLoginViewModel>(RoutePages.LoginPage);
            builder.Services.AddTransientWithShellRoute<RegisterUserAccountPage, RegisterUserAccountViewModel>(
                RoutePages.UserRegisterAccountPage);

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

        public MauiAppBuilder ConfigureServices()
        {
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            return builder;
        }

        public MauiAppBuilder ConfigurePlatformHandlers()
        {
            builder.ConfigureMauiHandlers(_ => CustomEntryHandler.Customize());
            return builder;
        }
    }
}