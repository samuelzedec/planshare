using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlanShare.App.Models;

namespace PlanShare.App.ViewModels.Pages.Login.DoLogin;

public sealed partial class DoLoginViewModel : ViewModelBase
{
    [ObservableProperty] 
    private LoginModel _model = new();

    [RelayCommand]
    private async Task DoLogin()
    {
        var test = Model;
    }
}