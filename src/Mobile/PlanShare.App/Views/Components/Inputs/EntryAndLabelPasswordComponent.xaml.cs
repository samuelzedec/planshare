namespace PlanShare.App.Views.Components.Inputs;

public partial class EntryAndLabelPasswordComponent : ContentView
{
    #region BindableProperties

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title), typeof(string), typeof(EntryAndLabelComponent), string.Empty);

    public static readonly BindableProperty TextValueProperty = BindableProperty.Create(
        nameof(TextValue), typeof(string), typeof(EntryAndLabelComponent), string.Empty, BindingMode.TwoWay);

    #endregion

    #region Properties

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string TextValue
    {
        get => (string)GetValue(TextValueProperty);
        set => SetValue(TextValueProperty, value);
    }

    #endregion

    public EntryAndLabelPasswordComponent()
        => InitializeComponent();

    private void ShowHidePassword(object? sender, TappedEventArgs e)
    {
        if (PasswordEntry.IsPassword)
        {
            PasswordEntry.IsPassword = false;
            ImageEye.Source = "icon_eye.png";
        }
        else
        {
            PasswordEntry.IsPassword = true;
            ImageEye.Source = "icon_eye_hidden.png";
        }
    }
}