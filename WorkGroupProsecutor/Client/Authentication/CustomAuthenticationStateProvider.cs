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
        //private const int SESSION_VALIDITY_MINS = 5; //#%$

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
                userSession.ExpiryTimeStamp = DateTime.Now.AddMonths(6); //AddMinutes(SESSION_VALIDITY_MINS);
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


    //public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    //{
    //    private readonly ISessionStorageService _sessionStorage;
    //    private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity()); //для анонимных пользователей

    //    public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage)
    //    {
    //        _sessionStorage = sessionStorage;
    //    }

    //    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    //    {
    //        try
    //        {
    //            var userSession = await _sessionStorage.ReadEncryptedItemAsync<UserSession>("UserSession");
    //            if (userSession == null)
    //            {
    //                return await Task.FromResult(new AuthenticationState(_anonymous));
    //            }
    //            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
    //            {
    //                new Claim(ClaimTypes.Name, userSession.UserName),
    //                new Claim(ClaimTypes.Role, userSession.Role)
    //            }, "JwtAuth")); //authentication type string value

    //            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
    //        }
    //        catch (Exception)
    //        {
    //            return await Task.FromResult(new AuthenticationState(_anonymous));
    //        }
    //    }

    //    public async Task UpdateAuthenticationState(UserSession? userSession) //при логауте этот парам-р будет null
    //    {
    //        ClaimsPrincipal claimsPrincipal;
    //        if (userSession != null)
    //        {
    //            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
    //            {
    //                new Claim(ClaimTypes.Name, userSession.UserName),
    //                new Claim(ClaimTypes.Role, userSession.Role)
    //            })); //как раз делаем тут что не доделали в JwtAuthenticationManager:
    //            userSession.ExpiryTimeStamp = DateTime.Now.AddSeconds(userSession.ExpiresIn); //проверит токен просрочен или нет
    //            await _sessionStorage.SaveItemEncryptedAsync("UserSession", userSession); //сохр-ем сессию юзера в session storage
    //        }
    //        else //user tries to log out
    //        {
    //            claimsPrincipal = _anonymous;
    //            await _sessionStorage.RemoveItemAsync("UserSession");
    //        }
    //        //notify Bzr about auth state change (part of auth-n state provider):
    //        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    //    }

    //    //метод для razor компонентов чтоб взять jwttoken from session storage //we need token while consuming an API
    //    public async Task<string> GetToken()
    //    {
    //        var result = string.Empty;

    //        try
    //        {
    //            var userSession = await _sessionStorage.ReadEncryptedItemAsync<UserSession>("UserSession");
    //            if (userSession != null && DateTime.Now < userSession.ExpiryTimeStamp) //checking if token expired
    //            {
    //                result = userSession.Token;
    //            }
    //        }
    //        catch (Exception)
    //        {
    //            throw;
    //        }

    //        return result;
    //    }
    //}
}
