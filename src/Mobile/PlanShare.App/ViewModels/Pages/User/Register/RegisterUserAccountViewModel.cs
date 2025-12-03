using PlanShare.App.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlanShare.App.Navigation;
using PlanShare.App.UseCases.User.Register;

namespace PlanShare.App.ViewModels.Pages.User.Register;

public sealed partial class RegisterUserAccountViewModel(
    INavigationService navigationService,
    IRegisterUserUseCase registerUserUseCase)
    : ObservableObject
{
    [ObservableProperty] 
    private UserRegisterAccountModel _model = new();

    [RelayCommand]
    private async Task RegisterAccount()
    {
        await registerUserUseCase.ExecuteAsync(Model);
    }

    [RelayCommand]
    private async Task GoToLogin()
        => await navigationService.GoToAsync($"../{RoutePages.LoginPage}");
}