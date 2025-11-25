#if IOS
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace PlanShare.App.Handlers;

/// <summary>
/// Handler customizado para Entry no iOS que remove a barra de ferramentas (toolbar) 
/// padrão do teclado, incluindo o botão azul de confirmação que aparece acima do teclado.
/// Mantém todas as outras funcionalidades padrões do Entry (placeholder, binding, eventos, etc.).
/// </summary>
public class CustomEntryHandler : EntryHandler
{
    /// <summary>
    /// Conecta o controle nativo (UITextField) ao Entry do MAUI.
    /// Aplica todas as configurações padrões e remove o InputAccessoryView para 
    /// ocultar a toolbar do teclado no iOS.
    /// </summary>
    /// <param name="platformView">Controle nativo UITextField do iOS</param>
    protected override void ConnectHandler(MauiTextField platformView)
    {
        base.ConnectHandler(platformView);
        platformView.InputAccessoryView = null;
    }
}
#endif