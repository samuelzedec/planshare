using CommunityToolkit.Maui;
using PlanShare.App.Extensions;

namespace PlanShare.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureAppSettings()
            .ConfigurePages()
            .ConfigureServices()
            .ConfigureMauiFonts()
            .ConfigurePlatformHandlers()
            .ConfigureHttpClients()
            .ConfigureUseCases();

        return builder.Build();
    }
}