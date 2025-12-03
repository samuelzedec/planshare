using PlanShare.App.Data.Network.Api;
using PlanShare.App.Models;
using PlanShare.Communication.Requests;

namespace PlanShare.App.UseCases.User.Register;

public sealed class RegisterUserUseCase(IUserApiClient userApiClient)
    : IRegisterUserUseCase
{
    public async Task ExecuteAsync(UserRegisterAccountModel model)
    {
        var request = new RequestRegisterUserJson { Email = model.Email, Name = model.Name, Password = model.Password };
        var response = await userApiClient.Register(request);
    }
}