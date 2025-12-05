using CommunityToolkit.Maui;
using PlanShare.App.Extensions;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace PlanShare.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseSkiaSharp()
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