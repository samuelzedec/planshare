namespace PlanShare.App.Views.Components.Inputs;

public partial class EntryAndLabelComponent : ContentView
{
    #region BindableProperties

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title), // Nome da propriedade
        typeof(string), // Tipo da propriedade
        typeof(EntryAndLabelComponent), // O tipo da classe que usa essa propriedade, para o MAUI saber que pertence a essa classe
        string.Empty // Valor padrão da propriedade
        // propertyChanged: Teste Uma das forma de fazer para setar os valores ao inicializar o componente
    );

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        nameof(Placeholder), typeof(string), typeof(EntryAndLabelComponent), string.Empty);

    public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(
        nameof(Keyboard), typeof(Keyboard), typeof(EntryAndLabelComponent), Keyboard.Default);

    #endregion

    #region Properties

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public Keyboard Keyboard
    {
        get => (Keyboard)GetValue(KeyboardProperty);
        set => SetValue(KeyboardProperty, value);
    }

    #endregion

    public EntryAndLabelComponent()
    {
        InitializeComponent();
        // Da para fazer que nem usando ViewModels
        // BindingContext = this;
    }
    
    // Ai passamos esse método para setar o valor, nesse caso é preciso colocar o x:Name no componente no xaml
    // private static void Teste(BindableObject bindable, object oldValue, object newValue)
    // {
    //     var component = bindable as EntryAndLabelComponent;
    //     component?.TitleLabel.Text = newValue.ToString();
    // }
}