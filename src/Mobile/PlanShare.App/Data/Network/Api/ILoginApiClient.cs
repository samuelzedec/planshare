using PlanShare.Communication.Requests;
using PlanShare.Communication.Responses;
using Refit;

namespace PlanShare.App.Data.Network.Api;

public interface ILoginApiClient
{
    [Post("/login")]
    Task<ResponseRegisteredUserJson> Login([Body] RequestLoginJson request);
}