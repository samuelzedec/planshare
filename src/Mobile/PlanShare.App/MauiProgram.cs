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
            .ConfigurePages()
            .ConfigureServices()
            .ConfigureMauiFonts()
            .ConfigurePlatformHandlers();

        return builder.Build();
    }
}