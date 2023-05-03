using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using WorkGroupProsecutor.Shared.Authentication;
using Blazored.LocalStorage;

namespace WorkGroupProsecutor.Client.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        private const int experationPeriod = 6;

        public CustomAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSession = await _localStorage.GetItemAsync<UserSession>("UserSession");
                if (userSession == null)
                    return await Task.FromResult(new AuthenticationState(_anonymous));

                if (userSession.ExpiryTimeStamp >= DateTime.Now)
                {
                    var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, userSession.UserName),
                        new Claim(ClaimTypes.Role, userSession.Role)
                    }, "CustomAuth"));
                    return await Task.FromResult(new AuthenticationState(claimsPrincipal));
                }
                else
                {
                    await _localStorage.RemoveItemAsync("UserSession");
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                }
            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
        }

        public async Task UpdateAuthenticationState(UserSession userSession)
        {
            ClaimsPrincipal claimsPrincipal;

            if (userSession != null)
            {
                userSession.ExpiryTimeStamp = DateTime.Now.AddMonths(experationPeriod);
                await _localStorage.SetItemAsync("UserSession", userSession);
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.UserName),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }));
            }
            else
            {
                await _localStorage.RemoveItemAsync("UserSession");
                claimsPrincipal = _anonymous;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}
