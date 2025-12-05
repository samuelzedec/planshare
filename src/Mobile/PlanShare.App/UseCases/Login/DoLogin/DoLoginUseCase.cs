using PlanShare.App.Data.Network.Api;
using PlanShare.App.Models;
using PlanShare.Communication.Requests;

namespace PlanShare.App.UseCases.Login.DoLogin;

public sealed class DoLoginUseCase(
    ILoginApiClient loginApiClient)
    : IDoLoginUseCase
{
    public async Task Execute(LoginModel model)
    {
        var request = new RequestLoginJson { Email = model.Email, Password = model.Password };
        var response = await loginApiClient.Login(request);
    }
}