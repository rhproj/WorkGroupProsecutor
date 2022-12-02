﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkGroupProsecutor.Server.Authentication;
using WorkGroupProsecutor.Shared.Authentication;

namespace WorkGroupProsecutor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserAccountService _userAccountService;
        public AccountController(UserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous] //IActionResult vv
        public async Task<ActionResult<UserSession>> Login([FromBody] LoginRequest loginRequest)
        {
            var jwtAuthManager = new JwtAuthenticationManager(_userAccountService);
            var userSession = await jwtAuthManager.GenerateJwtToken(loginRequest.UserName, loginRequest.Password);

            if (userSession is null)
                return Unauthorized();
            else
                return userSession;
        }


        [HttpGet("getUserDescription/{userName}")]
        public async Task<IActionResult> GetUserDescription(string userName)
        {
            //return Ok(await _userAccountService.GetUserDescriptionByUserName(userName));
            //return Ok((await _userAccountService.GetUserAccountByUserName(userName)).UserDescription);

            var userAccount = await _userAccountService.GetUserAccountByUserName(userName);
            if (userAccount == null)
                return null;

            return Ok(userAccount.UserDescription);
        }

       //[HttpGet("getByDistricts/{period}")]
       // public async Task<IActionResult> Get(int id)
       // {
       //     return Ok(await _appealRepository.GetRedirectedAppealById(id));
    }
}
