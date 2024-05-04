using App.API.Entites;
using App.API.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace App.API.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"]));
        }
        public string CreateToken(AppUser user)
        {

            var Claims = new List<Claim>
            {
                new Claim (ClaimTypes.Email , user.UserName ),
            };


            var creeds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: Claims,
                issuer: _config["Token:ValidIssuer"],
                audience: _config["Token:ValidAudiance"],
                signingCredentials: creeds,
                expires: DateTime.Now.AddDays(double.Parse(_config["Token:ExpirationTime"]))

                );


            return new JwtSecurityTokenHandler().WriteToken(token);            

        }
   
    
    
    }
}
