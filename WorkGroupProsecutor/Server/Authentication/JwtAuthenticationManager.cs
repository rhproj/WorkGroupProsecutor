using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WorkGroupProsecutor.Shared.Authentication;

namespace WorkGroupProsecutor.Server.Authentication
{
    public class JwtAuthenticationManager
    {
        public const string JWT_SECURITY_KEY = "eyJSb2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJJc3N1ZXIiLCJVc2Vybm";
        private UserAccountService _userAccountService;

        public JwtAuthenticationManager(UserAccountService uAservice)
        {
            _userAccountService = uAservice;
        }

        public async Task<UserSession?> GenerateJwtToken(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                return null;

            var userAccount = await _userAccountService.GetUserAccountByUserName(userName);
            if (userAccount == null || userAccount.Password != password)
                return null;

            string token = GenerateJWTtoken(userAccount);

            var userSession = new UserSession
            {
                UserName = userAccount.UserName,
                Role = userAccount.Role,
                Token = token
            };
            return userSession;
        }

        private static string GenerateJWTtoken(UserAccount userAccount)
        {
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);

            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, userAccount.UserName),
                new Claim(ClaimTypes.Role, userAccount.Role)
            });
            var signingCredential = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature);
            var securityTokenDescription = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                SigningCredentials = signingCredential
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescription);

            var token = jwtSecurityTokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
