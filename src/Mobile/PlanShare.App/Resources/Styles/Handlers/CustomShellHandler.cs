#if IOS
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using UIKit;

namespace PlanShare.App.Resources.Styles.Handlers;

public class CustomShellRenderer : ShellRenderer
{
    protected override IShellNavBarAppearanceTracker CreateNavBarAppearanceTracker()
        => new CustomNavBarAppearanceTracker(this);
    //
    // protected override IShellSectionRenderer CreateShellSectionRenderer(ShellSection shellSection)
    // {
    //     return new CustomShellSectionRenderer(this);
    // }
}

public class CustomNavBarAppearanceTracker(
    IShellContext shellContext)
    : IShellNavBarAppearanceTracker
{
    public void Dispose() { }

    public void ResetAppearance(UINavigationController controller)
    {
        // Força reset da visibilidade baseado nas configurações da página atual
        if (shellContext.Shell?.CurrentPage is null)
            return;

        var navBarIsVisible = Shell.GetNavBarIsVisible(shellContext.Shell.CurrentPage);
        controller.SetNavigationBarHidden(!navBarIsVisible, true);
    }

    public void SetAppearance(UINavigationController controller, ShellAppearance appearance)
    {
        var navBar = controller.NavigationBar;
        var navigationBarAppearance = new UINavigationBarAppearance();

        // Remove a linha separadora (sua funcionalidade existente)
        navigationBarAppearance.ShadowColor = UIColor.Clear;

        // Preserva Shell.BackgroundColor se definido
        if (appearance.BackgroundColor is not null)
        {
            var color = appearance.BackgroundColor;
            navigationBarAppearance.BackgroundColor = UIColor.FromRGBA(
                color.Red, color.Green,
                color.Blue, color.Alpha);
            // navigationBarAppearance.BackgroundColor = UIColor.FromRGBA(0, 122, 255, 255);
        }
        else
        {
            navigationBarAppearance.ConfigureWithTransparentBackground();
            navigationBarAppearance.BackgroundColor = UIColor.Clear;
        }

        // Preserva cor do título/foreground
        if (appearance.ForegroundColor is not null)
        {
            var fgColor = appearance.ForegroundColor;
            var uiFgColor = UIColor.FromRGBA(
                fgColor.Red, fgColor.Green,
                fgColor.Blue, fgColor.Alpha);

            // navigationBarAppearance.TitleTextAttributes = new UIStringAttributes { ForegroundColor = uiFgColor };
            navBar.TintColor = uiFgColor;
        }

        navBar.ScrollEdgeAppearance = navBar.StandardAppearance = navigationBarAppearance;
    }

    public void SetHasShadow(UINavigationController controller, bool hasShadow) { }

    public void UpdateLayout(UINavigationController controller)
    {
        // CRÍTICO: Força atualização da visibilidade durante mudanças de layout
        // (incluindo navegação de volta)
        if (shellContext.Shell?.CurrentPage is null)
            return;

        var navBarIsVisible = Shell.GetNavBarIsVisible(shellContext.Shell.CurrentPage);
        controller.SetNavigationBarHidden(!navBarIsVisible, false);
    }
}


// public class CustomShellHandler : ShellRenderer
// {
//     // protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
//     //     => new MyBottomNavViewAppearanceTracker();
//
//     protected override IShellNavBarAppearanceTracker CreateNavBarAppearanceTracker()
//         => new NoLineAppearanceTracker(this);
// }
//
// public class NoLineAppearanceTracker(IShellContext context) : IShellNavBarAppearanceTracker
// {
//     public void Dispose() { }
//
//     public void ResetAppearance(UINavigationController controller)
//     {
//         if (context.Shell?.CurrentPage is null)
//             return;
//
//         var navBarIsVisible = Shell.GetNavBarIsVisible(context.Shell.CurrentPage);
//         controller.SetNavigationBarHidden(!navBarIsVisible, true);
//     }
//
//     public void SetAppearance(UINavigationController controller, ShellAppearance appearance)
//     {
//         var navBar = controller.NavigationBar;
//         var navigationBarAppearance = new UINavigationBarAppearance();
//         // navigationBarAppearance.ConfigureWithTransparentBackground();
//         navigationBarAppearance.ConfigureWithOpaqueBackground();
//
//         var color = appearance.BackgroundColor;
//         // navigationBarAppearance.BackgroundColor = UIColor.FromRGBA(color.Red, color.Green, color.Blue, color.Alpha);
//         navigationBarAppearance.BackgroundColor = UIColor.FromRGBA(0, 122, 255, 255);
//
//         var fgColor = appearance.ForegroundColor;
//         var uiFgColor = UIColor.FromRGBA(fgColor.Red, fgColor.Green, fgColor.Blue, fgColor.Alpha);
//
//         navigationBarAppearance.TitleTextAttributes = new UIStringAttributes { ForegroundColor = uiFgColor };
//
//         navigationBarAppearance.ShadowColor = UIColor.Clear;
//         // navigationBarAppearance.BackgroundEffect = null;
//
//         // navBar.StandardAppearance = navigationBarAppearance;
//         // navBar.ScrollEdgeAppearance = navigationBarAppearance;
//         navBar.ScrollEdgeAppearance = navBar.StandardAppearance = navigationBarAppearance;
//
//         navBar.SetNeedsLayout();
//         navBar.LayoutIfNeeded();
//         controller.NavigationBar.SetNeedsLayout();
//         controller.NavigationBar.LayoutIfNeeded();
//     }
//
//     public void SetHasShadow(UINavigationController controller, bool hasShadow) { }
//
//     public void UpdateLayout(UINavigationController controller)
//     {
//         // controller.View?.SetNeedsLayout();
//         // controller.View?.LayoutIfNeeded();
//         // controller.NavigationBar.SetNeedsLayout();
//         // controller.NavigationBar.LayoutIfNeeded();
//     }
// }
//
// class MyBottomNavViewAppearanceTracker : IShellTabBarAppearanceTracker
// {
//     public void Dispose() { }
//
//     public void ResetAppearance(UITabBarController controller) { }
//
//     public void SetAppearance(UITabBarController controller, ShellAppearance appearance)
//     {
//         var topBar = controller.TabBar;
//         var topBarAppearance = new UITabBarAppearance();
//         topBarAppearance.ConfigureWithTransparentBackground();
//         topBarAppearance.ShadowColor = UIColor.Clear;
//         topBarAppearance.BackgroundColor = UIColor.Clear;
//         topBarAppearance.BackgroundEffect = null;
//         topBar.ScrollEdgeAppearance = topBar.StandardAppearance = topBarAppearance;
//     }
//
//     public void UpdateLayout(UITabBarController controller) { }
// }
#endif