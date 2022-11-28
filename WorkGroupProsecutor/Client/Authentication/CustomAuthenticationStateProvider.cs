﻿using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using WorkGroupProsecutor.Shared.Authentication;

namespace WorkGroupProsecutor.Client.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity()); //для анонимных пользователей

        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSession = await _sessionStorage.ReadEncryptedItemAsync<UserSession>("UserSession");
                if (userSession == null)
                {
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                }
                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.UserName),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }, "JwtAuth")); //JwtAuth - !важно! стринг предоставленный типу аутентификации, без него юзер будет анонимным

                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch (Exception)
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
        }
        //когда происходит вход/выход метод кот-й апдэйтит SessionStorage(сессию) & notify bzr about auth.state change:
        public async Task UpdateAuthenticationState(UserSession? userSession) //при логауте этот парам-р будет null
        {
            ClaimsPrincipal claimsPrincipal;
            if (userSession != null) //означает юзер пыт-ся войти
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.UserName),
                    new Claim(ClaimTypes.Role, userSession.Role)
                })); //как раз делаем тут что не доделали в JwtAuthenticationManager:
                userSession.ExpiryTimeStamp = DateTime.Now.AddSeconds(userSession.ExpiresIn); //проверит токен просрочен или нет
                await _sessionStorage.SaveItemEncryptedAsync("UserSession", userSession); //сохр-ем сессию юзера в session storage
            }
            else //user tries to log out
            {
                claimsPrincipal = _anonymous;
                await _sessionStorage.RemoveItemAsync("UserSession");
            }
            //notify Bzr about auth state change:
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        //метод для razor компонентов чтоб взять jwttoken from session storage //we need token while consuming an API
        public async Task<string> GetToken()
        {
            var result = string.Empty;

            try
            {
                var userSession = await _sessionStorage.ReadEncryptedItemAsync<UserSession>("UserSession");
                if (userSession != null && DateTime.Now < userSession.ExpiryTimeStamp) //checking if token expired
                {
                    result = userSession.Token;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}