using App.API.Interfaces;
using App.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace App.API.Extension
{
    public static  class ApplicationIdentityExtension
    {

        public static IServiceCollection AddIdentityServices(this IServiceCollection services , IConfiguration config)
        {

            services.AddScoped<ITokenService, TokenService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                        ValidateIssuer = true,
                        ValidIssuer = config["Token:ValidIssuer"],
                        ValidateAudience = true,
                        ValidAudience = config["Token:ValidAudiance"],
                        ValidateLifetime = true,


                    };
                });




            return services;
        }

    }
}
