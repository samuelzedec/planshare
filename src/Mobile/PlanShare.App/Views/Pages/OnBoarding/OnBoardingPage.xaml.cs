using PlanShare.App.ViewModels.Pages.OnBoarding;

namespace PlanShare.App.Views.Pages.OnBoarding;

public partial class OnBoardingPage : ContentPage
{
    public OnBoardingPage()
    {
        /*
         * Carrega o XAML vinculado a esta classe e converte em objetos C#,
         * preparando-os para serem renderizados pelo engine nativo
         */
        InitializeComponent();

        /*
         * Faz a conexão dessa view a classe de ViewModel
         */
        BindingContext = new OnBoardingViewModel();
    }
}