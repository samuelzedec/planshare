using PlanShare.App.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlanShare.App.Enums;
using PlanShare.App.Navigation;
using PlanShare.App.UseCases.User.Register;

namespace PlanShare.App.ViewModels.Pages.User.Register;

public sealed partial class RegisterUserAccountViewModel(
    INavigationService navigationService,
    IRegisterUserUseCase registerUserUseCase)
    : ViewModelBase
{
    [ObservableProperty] 
    private UserRegisterAccountModel _model = new();

    [RelayCommand]
    private async Task RegisterAccount()
    {
        StatusPage = StatusPage.Sending;
        await registerUserUseCase.ExecuteAsync(Model);
        StatusPage = StatusPage.Default;
    }

    [RelayCommand]
    private async Task GoToLogin()
        => await navigationService.GoToAsync($"../{RoutePages.LoginPage}");
}