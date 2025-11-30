using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using PlanShare.App.Extensions;

namespace PlanShare.App.Resources.Styles.Handlers;

/*
 * Um handler é o que faz o mapeamento de um elemento virtual para um elemento nativo conforme
 * a plataforma. Aqui você pode fazer customizações globais para todos os Entry da aplicação.
 */
public static class CustomEntryHandler
{
    public static void Customize()
    {
        EntryHandler.Mapper.AppendToMapping("PlanShareEntry", (handler, entry) =>
        {
            var cursorColor = Application.Current!.GetPrimaryColor();
            var lineColor = Application.Current!.GetLineColor();


#if ANDROID
            handler.PlatformView.TextCursorDrawable?.SetTint(cursorColor.ToPlatform());
            handler.PlatformView.Background?.SetTint(lineColor.ToPlatform());
#elif IOS || MACCATALYST
            handler.PlatformView.Layer.BorderColor = lineColor.ToCGColor();
            handler.PlatformView.Layer.CornerRadius = 6.8f;
            handler.PlatformView.Layer.BorderWidth = 0.7f;
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            handler.PlatformView.TintColor = cursorColor.ToPlatform();
            handler.PlatformView.InputAccessoryView = null;
#endif
        });
    }
}