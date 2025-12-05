using CommunityToolkit.Mvvm.ComponentModel;
using PlanShareEnums = PlanShare.App.Enums;

namespace PlanShare.App.ViewModels.Pages;

public abstract partial class ViewModelBase : ObservableObject
{
    [ObservableProperty] 
    private PlanShareEnums::StatusPage _statusPage = PlanShareEnums::StatusPage.Default;
}