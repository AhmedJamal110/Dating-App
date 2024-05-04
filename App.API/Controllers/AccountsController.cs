using App.API.DataContext;
using App.API.Dtos;
using App.API.Entites;
using App.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace App.API.Controllers
{
  
    public class AccountsController : BaseController
    {
        private readonly DataDbContext _context;
        private readonly ITokenService _token;

        public AccountsController( DataDbContext context , ITokenService token)
        {
            _context = context;
            _token = token;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Regisrter(RegisterDto model)
        {
            if (await IsExsist(model.UserName))
            {
                return BadRequest("Email Exsist");
            }

            //var hmac = new HMACSHA512;
            using var hmac = new HMACSHA512();


            var user = new AppUser
            {
                UserName = model.UserName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Password)),
                Passwordsalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        //    {
        //        UserName = user.UserName,
        //        Token = _token.CreateToken(user)
        //}

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto model)
        {
            var user = await _context.Users.SingleOrDefaultAsync(U => U.UserName == model.UserName);

            if (user is null)
                return Unauthorized("Email Invalid");

            using var hmac = new HMACSHA512(user.Passwordsalt);
            var computHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
            for (int i = 0; i < computHash.Length; i++)
            {
                if (computHash[i]  != user.PasswordHash[i])
                    return Unauthorized("Password Invalid");
            }
            return new UserDto
            {
                UserName = user.UserName,
                Token = _token.CreateToken(user)
            };
        }


        private async Task<bool> IsExsist(string username)
        {
            return await _context.Users.AnyAsync(U => U.UserName == username.ToLower());
        }

    }
}
