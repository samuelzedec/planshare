using PlanShare.App.Models;

namespace PlanShare.App.UseCases.Login.DoLogin;

public interface IDoLoginUseCase
{
    Task Execute(LoginModel model);
}