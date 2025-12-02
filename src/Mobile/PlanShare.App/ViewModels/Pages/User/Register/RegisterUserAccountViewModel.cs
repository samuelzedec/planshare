using PlanShare.App.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlanShare.App.Navigation;

namespace PlanShare.App.ViewModels.Pages.User.Register;

public sealed partial class RegisterUserAccountViewModel(
    INavigationService navigationService)
    : ObservableObject
{
    [ObservableProperty] 
    private UserRegisterAccountModel _model = new();

    [RelayCommand]
    private async Task RegisterAccount()
    {
        var modelTest = Model;
    }

    [RelayCommand]
    private async Task GoToLogin()
        => await navigationService.GoToAsync($"../{RoutePages.LoginPage}");
}