using CommunityToolkit.Mvvm.Input;
using PlanShare.App.Navigation;

namespace PlanShare.App.ViewModels.Pages.OnBoarding;

public partial class OnBoardingViewModel
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
    private static async Task LoginWithEmailAndPassword()
        => await Shell.Current.GoToAsync(RoutePages.LoginPage);

    [RelayCommand] // Faz tudo que está em cima so que de forma implicita
    private void LoginWithGoogle()
    {
    }
    
    [RelayCommand]
    private static async Task RegisterUserAccount()
        => await Shell.Current.GoToAsync(RoutePages.UserRegisterAccountPage);
}