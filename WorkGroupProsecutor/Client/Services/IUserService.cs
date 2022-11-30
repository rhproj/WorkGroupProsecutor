using WorkGroupProsecutor.Shared.Authentication;

namespace WorkGroupProsecutor.Client.Services
{
    public interface IUserService
    {
        Task<HttpResponseMessage> AuthenticateUser(LoginRequest loginRequest);

        Task<string> GetUserDescription(string district);
    }
}
