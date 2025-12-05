#if IOS
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;
using UIKit;

namespace PlanShare.App.Resources.Styles.Handlers;

public class CustomShellHandler : ShellRenderer
{
    // protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
    //     => new MyBottomNavViewAppearanceTracker();

    protected override IShellNavBarAppearanceTracker CreateNavBarAppearanceTracker()
        => new NoLineAppearanceTracker();
}

public class NoLineAppearanceTracker : IShellNavBarAppearanceTracker
{
    public void Dispose() { }

    public void ResetAppearance(UINavigationController controller) { }

    public void SetAppearance(UINavigationController controller, ShellAppearance appearance)
    {
        var navBar = controller.NavigationBar;
        var navigationBarAppearance = new UINavigationBarAppearance();
        // navigationBarAppearance.ConfigureWithTransparentBackground();
        navigationBarAppearance.ConfigureWithOpaqueBackground();
        navigationBarAppearance.BackgroundColor = appearance.BackgroundColor.ToPlatform();

        navigationBarAppearance.TitleTextAttributes = new UIStringAttributes
        {
            ForegroundColor = appearance.ForegroundColor.ToPlatform()
        };

        navigationBarAppearance.ShadowColor = UIColor.Clear;
        // navigationBarAppearance.BackgroundEffect = null;

        navBar.StandardAppearance = navigationBarAppearance;
        // navBar.ScrollEdgeAppearance = navigationBarAppearance;
        // navBar.ScrollEdgeAppearance = navBar.StandardAppearance = navigationBarAppearance;
    }

    public void SetHasShadow(UINavigationController controller, bool hasShadow) { }

    public void UpdateLayout(UINavigationController controller) { }
}
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