using CommunityToolkit.Mvvm.Input;
using PlanShare.App.Navigation;

namespace PlanShare.App.ViewModels.Pages.OnBoarding;

public sealed partial class OnBoardingViewModel(
    INavigationService navigationService)
    : ViewModelBase
{
    // public ICommand LoginWithEmailAndPasswordCommand { get; set; }
    //
    // public OnBoardingViewModel()
    // {
    //     LoginWithEmailAndPasswordCommand = new Command(LoginWithEmailAndPassword);
    // }

    // Ao usar assim, não é mais preciso escrever tudo aquilo de código
    // e pegará o nome da função abaixo e colocar Command no final, ficando disponivel
    // como LoginWithEmailAndPasswordCommand no XAML
    // Pode ser privado, para encapsular e deixar somente o comando exposto
    [RelayCommand]
    private async Task LoginWithEmailAndPassword()
        => await navigationService.GoToAsync(RoutePages.LoginPage);

    [RelayCommand] // Faz tudo que está em cima so que de forma implicita
    private static void LoginWithGoogle()
    {
        Application.Current?.UserAppTheme = Application.Current.UserAppTheme is AppTheme.Dark
            ? AppTheme.Light : AppTheme.Dark;
    }

    [RelayCommand]
    private async Task RegisterUserAccount()
        => await navigationService.GoToAsync(RoutePages.UserRegisterAccountPage);
}