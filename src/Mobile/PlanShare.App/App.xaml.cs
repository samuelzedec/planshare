namespace PlanShare.App;

/**
 * É executado após o MauiProgram, aqui é usado para fazer
 * coisas ao iniciar a aplicação
 */
public partial class App : Application
{
    public App()
        => InitializeComponent();

    /*
     * O método CreateWindow cria a janela (container) da aplicação.
     * A janela recebe o AppShell como conteúdo e é entregue para o
     * engine nativo da plataforma (UIKit/Android/WinUI), que faz a
     * renderização de tudo que está dentro dessa janela na tela física.
     *
     * O AppShell gerencia a navegação, define as rotas disponíveis
     * e qual será a tela inicial (primeira ShellContent).
     */
    protected override Window CreateWindow(IActivationState? activationState)
        => new(new AppShell());
}