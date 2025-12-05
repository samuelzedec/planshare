using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlanShare.App.Enums;
using PlanShare.App.Models;
using PlanShare.App.UseCases.Login.DoLogin;

namespace PlanShare.App.ViewModels.Pages.Login.DoLogin;

public sealed partial class DoLoginViewModel(
    IDoLoginUseCase doLoginUseCase)
    : ViewModelBase
{
    [ObservableProperty] private LoginModel _model = new();

    [RelayCommand]
    private async Task DoLogin()
    {
        StatusPage = StatusPage.Sending;
        await doLoginUseCase.Execute(Model);
        StatusPage = StatusPage.Default;
    }
}